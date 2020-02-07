using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EBookStore.Repository.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token);

        Task<TEntity> CreateAsync(TEntity entity);

        void Update(int id, TEntity entity);

        void Delete(TEntity entity);

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
