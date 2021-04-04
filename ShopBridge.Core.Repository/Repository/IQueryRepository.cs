using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Core.Repository.Repository
{
    /// <summary>
    /// Use the concept of Interface segregation principle to break the fat Interface into small interface
    /// Hence so client can use required interface only.
    /// 
    /// This is query interface which has only  query Like GetAll, GetSingle and GetFIltered
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="T"></typeparam>
    public interface IQueryRepository<TEntity,T> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetEntityList();
        Task<IEnumerable<TEntity>> FilteredEntity(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties);
        Task<TEntity> GetSingle(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties);

    }
}
