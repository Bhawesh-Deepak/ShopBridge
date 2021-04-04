using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopBridge.Core.Entity.Common;
using ShopBridge.Core.Entity.Inventory;
using ShopBridge.Core.Entity.ShopBridgeContext;
using ShopBridge.Core.Repository.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Infrastructure.Repository.Inventory
{
    public class ProductRepository : IProductRepository
    {
        private BridgeContext bridgeContext;

        public ProductRepository(IConfiguration confifuration)
        {
            bridgeContext = new BridgeContext();
        }
        public async Task<ResponseMessage> CreateEntity(Product entity)
        {
            try
            {
                bridgeContext.Products.Add(entity);
                var response = await bridgeContext.SaveChangesAsync();
                return ResponseMessage.Added;
            }
            catch (Exception ex)
            {
                return ResponseMessage.ExceptionOccured;
            }
        }

        public async Task<ResponseMessage> DeleteEntity(int entityId)
        {
            try
            {
                if(bridgeContext.Products.Any(x=>x.Id==entityId))
                {
                    var deleteModel = bridgeContext.Products.Find(entityId);
                    bridgeContext.Products.Remove(deleteModel);
                    var response = await bridgeContext.SaveChangesAsync();
                    return ResponseMessage.Deleted;
                }
                return ResponseMessage.NotFound;
     
            }
            catch (Exception ex)
            {
                return ResponseMessage.ExceptionOccured;
            }
        }

        public async Task<IEnumerable<Product>> FilteredEntity(Func<Product, bool> where, params Expression<Func<Product, object>>[] navigationProperties)
        {
            List<Product> list;
            IQueryable<Product> dbQuery = bridgeContext.Set<Product>();

            //Apply eager loading
            foreach (Expression<Func<Product, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<Product, object>(navigationProperty);
            }

            list = dbQuery.AsNoTracking().Where(where).ToList<Product>();
            return await Task.Run(() => list);
        }

        public async Task<IEnumerable<Product>> GetEntityList()
        {
            List<Product> list;
            IQueryable<Product> dbQuery = bridgeContext.Set<Product>();
            list = dbQuery.AsNoTracking().ToList<Product>();
            return await Task.Run(() => list);
        }


        public async Task<Product> GetSingle(Func<Product, bool> where, params Expression<Func<Product, object>>[] navigationProperties)
        {
            Product productModel;
            IQueryable<Product> dbQuery = bridgeContext.Set<Product>();

            //Apply eager loading
            foreach (Expression<Func<Product, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<Product, object>(navigationProperty);
            }

            productModel = dbQuery.AsNoTracking().FirstOrDefault(where);
            return await Task.Run(() => productModel);
        }

        public async Task<ResponseMessage> UpdateEntity(Product entity)
        {
            try
            {
                bridgeContext.Products.Update(entity);
                var response = await bridgeContext.SaveChangesAsync();
                return ResponseMessage.Updated;
            }
            catch(Exception ex)
            {
                return ResponseMessage.ExceptionOccured;
            }
        }
    }
}
