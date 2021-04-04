using Microsoft.Extensions.DependencyInjection;
using ShopBridge.Core.Repository.Inventory;
using ShopBridge.Infrastructure.Repository.Inventory;


namespace ShopBridge.Infrastructure.Repository.RepositoryExtension
{
    public static class RepositoryExtensions
    {
        public static void AddRepositoryService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
