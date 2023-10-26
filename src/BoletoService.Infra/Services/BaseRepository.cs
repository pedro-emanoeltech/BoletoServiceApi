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
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, IEntity
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
                await _context.Set<TEntity>().AddAsync(TEntity);
                await _dbSet.AddAsync(TEntity);
                if (saveChanges)
                {
                    await _context.SaveChangesAsync();
                }
                return TEntity;
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
                _dbSet.Update(TEntity);
                if (saveChanges)
                {
                    await _context.SaveChangesAsync();
                }

                return TEntity;
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

                TEntity TEntity = await Get(id);
                if (TEntity is not null)
                {
                    _context.Set<TEntity>().Remove(TEntity);
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

        public virtual async Task<TEntity> Get(Guid id)
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

        public virtual async Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
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

        public virtual async Task<IEnumerable<TEntity>> GetToList(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
