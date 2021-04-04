using ShopBridge.Core.Entity.Inventory;
using ShopBridge.Core.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Core.Service.Inventory
{
    public interface IProductService : IQueryService<Product, int>, ICommandService<Product, int>
    {
    }
}
