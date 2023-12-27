using GoldenSmith.Domain.Repositories;
using GoldenSmith.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Infrastructure.Modules
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IJewelryRepo, JewelryRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
            services.AddScoped<IJewelryImageRepo, JewelryImageRepo>();
            services.AddScoped<IJewelryReviewRepo, JewelryReviewRepo>();
            return services;
        }
    }
}
