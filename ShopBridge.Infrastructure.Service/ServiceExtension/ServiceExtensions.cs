using Microsoft.Extensions.DependencyInjection;
using ShopBridge.Core.Service.Inventory;
using ShopBridge.Infrastructure.Service.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Infrastructure.Service.ServiceExtension
{
    public static class ServiceExtensions
    {
        public static void AddServicesService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductService, ProductServcie>();
        }
    }
}
