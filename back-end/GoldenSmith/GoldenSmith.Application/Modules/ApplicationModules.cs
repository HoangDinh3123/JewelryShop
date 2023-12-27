using AutoMapper;
using GoldenSmith.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using GoldenSmith.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenSmith.Application.Mapping;

namespace GoldenSmith.Application.Modules
{
    public static class ApplicationModules
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddInfrastructureModule();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IJewelryService, JewelryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IJewelryImageService, JewelryImageService>();
            services.AddScoped<IJewelryReviewService, JewelryReviewService>();
            return services;
        }
    }
}
