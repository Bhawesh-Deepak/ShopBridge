using ShopBridge.Core.Entity.Common;
using ShopBridge.Core.Entity.Inventory;
using ShopBridge.Core.Repository.Inventory;
using ShopBridge.Core.Service.Inventory;
using Shoping.Bridge.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopBridge.Infrastructure.Service.Inventory
{
    public class ProductServcie : IProductService
    {
        private readonly IProductRepository _IProductRepository;

        public ProductServcie(IProductRepository productRepository)
        {
            _IProductRepository = productRepository;
        }
        public async Task<ResponseMessage> CreateEntity(Product entity)
        {
            return await _IProductRepository.CreateEntity(entity);
        }

        public async Task<ResponseMessage> DeleteEntity(int entityId)
        {
            return await _IProductRepository.DeleteEntity(entityId);
        }

        public async Task<ResponseModel<Product>> FilteredEntity(int currentPage, int maxRow, Func<Product, bool> where, params Expression<Func<Product, object>>[] navigationProperties)
        {
            var response = await _IProductRepository.FilteredEntity(where, navigationProperties);

            var result = (from data in response
                          select data).OrderBy(x => x.Id)
                          .Skip((currentPage - 1) * maxRow)
                          .Take(maxRow).ToList();

            double pageCount = (double)((decimal)response.Count() / Convert.ToDecimal(maxRow));
            int PageCount = (int)Math.Ceiling(pageCount);

            int CurrentPageIndex = currentPage;

            var responseModel = new ResponseModel<Product>()
            {
                PageCount = pageCount,
                models = result,
                PageIndex = CurrentPageIndex
            };
            return responseModel;
        }

        public async Task<ResponseModel<Product>> GetEntityList(int currentPage, int maxRow)
        {
            //Get all the required record.
            var response = await _IProductRepository.GetEntityList();
            var result = (from data in response
                          select data).OrderBy(x => x.Id).Skip((currentPage - 1) * maxRow).Take(maxRow).ToList();

            //Find the all the records we have

            double pageCount = (double)((decimal)response.Count() / Convert.ToDecimal(maxRow));
            int PageCount = (int)Math.Ceiling(pageCount);

            int CurrentPageIndex = currentPage;

            var responseModel = new ResponseModel<Product>()
            {
                PageCount = pageCount,
                models = result,
                PageIndex = CurrentPageIndex
            };
            return responseModel;
        }

        public async Task<Product> GetSingle(Func<Product, bool> where, params Expression<Func<Product, object>>[] navigationProperties)
        {
            return await _IProductRepository.GetSingle(where, navigationProperties);
        }

        public async Task<ResponseMessage> UpdateEntity(Product entity)
        {
            return await _IProductRepository.UpdateEntity(entity);
        }
    }
}
