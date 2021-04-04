using ShopBridge.Core.Entity.Common;
using System.Threading.Tasks;

namespace ShopBridge.Core.Repository.Repository
{
    /// <summary>
    /// Use the concept of Interface segregation principle to break the fat Interface into small interface
    /// Hence so client can use required interface only.
    /// 
    /// This is command interface which has only command query Like Update, Create and Delete
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="T"></typeparam>
    public interface ICommandRepository<TEntity,T> where TEntity :class
    {
        Task<ResponseMessage> CreateEntity(TEntity entity);
        Task<ResponseMessage> UpdateEntity(TEntity entity);
        Task<ResponseMessage> DeleteEntity(T entityId);
    }
}
