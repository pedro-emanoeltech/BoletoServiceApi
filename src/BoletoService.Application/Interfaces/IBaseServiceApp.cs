using BoletoService.Shared.Abstractions;
using BoletoService.Shared.Messages;

namespace BoletoService.Application.Interfaces
{
    public interface IBaseServiceApp<TEntity, TEntityRequest, TEntityResponse>
        where TEntity : BaseEntity, IEntity
        where TEntityRequest : IDtoRequest
        where TEntityResponse : IDtoResponse
    {
        Task<T> Add(T Entity, bool saveChanges = true);
        Task<T?> Get(string id);
        Task<IList<T>> GetList(string ContaId = "");
        Task<bool> Remove(string id);
        Task<T> Edit(string id, T TEntity);

    }
}
