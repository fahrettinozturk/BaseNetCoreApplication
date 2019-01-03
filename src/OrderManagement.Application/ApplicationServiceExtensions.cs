using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using OrderManagement.Application.Order;
using OrderManagement.Application.Product;

namespace OrderManagement.Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddOrderManagementApplication(this IServiceCollection services)
        {
            services.AddAutoMapper();

            // ToDo --> Add New Services for them to be added to the container!!
            services.AddTransient<IOrderAppService, OrderAppService>();
            services.AddTransient<IProductAppService, ProductAppService>();

            return services;
        }
    }
}
