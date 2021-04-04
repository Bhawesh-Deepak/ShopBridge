using Shoping.Bridge.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Core.Service.Services
{
    public interface IQueryService<TEntity, T> where TEntity : class
    {
        Task<ResponseModel<TEntity>> GetEntityList(int currentPage, int maxRow);
        Task<ResponseModel<TEntity>> FilteredEntity(int currentPage, int maxRow,Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties);
        Task<TEntity> GetSingle(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties);
    }
}
