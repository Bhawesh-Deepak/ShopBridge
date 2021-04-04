using ShopBridge.Core.Entity.Common;
using System.Threading.Tasks;

namespace ShopBridge.Core.Service.Services
{
    public interface ICommandService<TEntity, T> where TEntity : class
    {
        Task<ResponseMessage> CreateEntity(TEntity entity);
        Task<ResponseMessage> UpdateEntity(TEntity entity);
        Task<ResponseMessage> DeleteEntity(T entityId);
    }
}
