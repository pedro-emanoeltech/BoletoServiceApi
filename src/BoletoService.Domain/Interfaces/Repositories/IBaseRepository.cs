﻿using Pe.Shared.Abstractions;
using System.Linq.Expressions;


namespace BoletoService.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, IEntity
    {
        Task<TEntity> Add(TEntity entity, bool saveChanges = true);

        Task<TEntity> Update(TEntity entity, bool saveChanges = true);

        Task<bool> Remove(Guid id);

        Task<TEntity?> Get(Guid id);

        Task<TEntity?> GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>?> GetToList(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, object>>? orderBy = null);

    }
}
