using GoldenSmith.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using GoldenSmith.Application.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationModule();

builder.Services.AddControllers();
builder.Services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<JewelryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("JewelryConnect"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [Space] then your token"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
});

//Add Authentication Bearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //Có kiểm tra Issuer
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuser"],
            //Có kiểm tra Audience
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            //Yêu cầu phải có thời gian hết hạn của token
            RequireExpirationTime = true,
            ValidateLifetime = true,
            //Lấy ra khóa bí mật
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
            RequireSignedTokens = true
        };
    });


var app = builder.Build();
app.UseCors("MyPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
