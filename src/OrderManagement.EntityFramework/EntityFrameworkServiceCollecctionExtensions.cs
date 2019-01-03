using Microsoft.Extensions.DependencyInjection;
using OrderManagement.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.EntityFramework
{
    public static class EntityFrameworkServiceCollecctionExtensions
    {
        public static IServiceCollection AddOrderManagementEntityFramework(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<OrderManagementDbContext>();

            return services;
        }
    }
}
