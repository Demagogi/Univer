using System.Linq.Expressions;

namespace Univer.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, bool tracking, params Expression<Func<TEntity, object>>[] includes);
        public Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
        public Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        public void Create(TEntity entity);
        public Task DeleteAsync(Guid id);
        public void Dispose();
    }
}
