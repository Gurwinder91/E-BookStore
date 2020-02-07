using EBookStore.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EBookStore.Repository.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _entities;

        protected Repository(DbContext context)
        {
            _dbContext = context;
            _entities = _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities.AsNoTracking();
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
        {
            return _entities.AsNoTracking().Where(expression);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token)
        {
            return await _entities.AsNoTracking().FirstOrDefaultAsync(expression, token);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            return entity;
        }

        public void Update(int id, TEntity entity)
        {
            _entities.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public async Task<int> SaveChangesAsync(CancellationToken token)
        {
            return await _dbContext.SaveChangesAsync(token);
        }
    }
}
