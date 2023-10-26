using BoletoService.Shared.Abstractions;

namespace BoletoService.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity, IEntity
    {
        Task<TEntity> Add(TEntity entity, bool saveChanges = true);

        Task<TEntity> Update(TEntity entity, bool saveChanges = true);

        Task<bool> Remove(Guid id);

        Task<TEntity?> Get(Guid id);

        void Dispose();
    }
}
