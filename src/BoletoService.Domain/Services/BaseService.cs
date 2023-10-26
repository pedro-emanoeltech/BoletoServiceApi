using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Domain.Interfaces.Services;
using BoletoService.Shared.Abstractions;

namespace BoletoService.Domain.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity, IEntity
    {
        private readonly IBaseRepository<TEntity> _repository;

        protected readonly IUnitOfWork _unitOfWork;

        protected BaseService(IBaseRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TEntity> Add(TEntity entity, bool saveChanges = true)
        {
            return await _repository.Add(entity, saveChanges);
        }

        public virtual async Task<TEntity?> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            return await _repository.Remove(id);
        }

        public async Task<TEntity> Update(TEntity entity, bool saveChanges = true)
        {
            return await _repository.Update(entity, saveChanges);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
