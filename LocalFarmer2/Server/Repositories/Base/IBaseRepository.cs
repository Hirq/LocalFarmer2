using System.Linq.Expressions;

namespace LocalFarmer2.Server.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> whereExpression, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> whereExpression);

        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> whereExpression, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> whereExpression);

        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> whereExpression, params Expression<Func<TEntity, object>>[] includeProperties);

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity);

        void Delete(TEntity entity);

        Task DeleteAsync(TEntity entity);

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
