using ShopBridge.Core.Entity.Inventory;
using ShopBridge.Core.Repository.Repository;

namespace ShopBridge.Core.Repository.Inventory
{
    public interface IProductRepository: IQueryRepository<Product, int>, ICommandRepository<Product, int>
    {
    }
}
