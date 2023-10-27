using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Infra.Context;
using BoletoService.Shared.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace BoletoService.Infra.Services
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity, IEntity
    {
        protected readonly BoletoContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(BoletoContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public virtual async Task<TEntity> Add(TEntity entity, bool saveChanges = true)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _dbSet.AddAsync(entity);
                if (saveChanges)
                {
                    await _context.SaveChangesAsync();
                }
                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<TEntity> Update(TEntity entity, bool saveChanges = true)
        {
            try
            {
                _dbSet.Update(entity);
                if (saveChanges)
                {
                    await _context.SaveChangesAsync();
                }

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<bool> Remove(Guid id)
        {
            try
            {
                TEntity? entity = await Get(id);
                if (entity is not null)
                {
                    _context.Set<TEntity>().Remove(entity);
                    await _context.SaveChangesAsync();
                    return true;

                }

                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<TEntity?> Get(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new Exception("Id invalido para operacao");
                }
                return await _dbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<TEntity?> GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(predicate);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<IEnumerable<TEntity>?> GetToList(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, object>>? orderBy = null)
        {
            try
            {
                IQueryable<TEntity> query = _dbSet.AsNoTracking();

                if (predicate != null)
                {
                    query = query.Where(predicate);
                }

                if (orderBy != null)
                {
                    query = query.OrderBy(orderBy);
                }

                return await query.ToListAsync();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
