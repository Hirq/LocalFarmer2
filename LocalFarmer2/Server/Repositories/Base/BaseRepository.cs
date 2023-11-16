using LocalFarmer2.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using static LocalFarmer2.Shared.Models.MyType;

namespace LocalFarmer2.Server.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly LocalfarmerDbContext _context;

        public BaseRepository(LocalfarmerDbContext context)
        {
            _context = context;
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> whereExpression)
        {
            var element = _context.Set<TEntity>().Where(whereExpression).AsNoTracking().FirstOrDefault();

            if (element == null)
            {
                var typeNameAttribute = typeof(TEntity).GetCustomAttribute<TypeNameAttribute>();
                var entityTypeName = typeNameAttribute?.TypeName ?? typeof(TEntity).Name;
                throw new KeyNotFoundException($"Not found object {entityTypeName}");
            }

            return element;
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> whereExpression)
        {
            var element = await _context.Set<TEntity>().Where(whereExpression).AsNoTracking().FirstOrDefaultAsync();

            if (element == null)
            {
                var typeNameAttribute = typeof(TEntity).GetCustomAttribute<TypeNameAttribute>();
                var entityTypeName = typeNameAttribute?.TypeName ?? typeof(TEntity).Name;
                throw new KeyNotFoundException($"Not found object {entityTypeName}");
            }

            return element;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(entity));
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Remove(entity));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> whereExpression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(whereExpression);

            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> whereExpression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _context.Set<TEntity>().Where(whereExpression).AsNoTracking();

            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            var element = await query.FirstOrDefaultAsync();

            if (element == null)
            {
                var typeNameAttribute = typeof(TEntity).GetCustomAttribute<TypeNameAttribute>();
                var entityTypeName = typeNameAttribute?.TypeName ?? typeof(TEntity).Name;
                throw new KeyNotFoundException($"Not found object {entityTypeName}");
            }

            return element;
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> whereExpression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _context.Set<TEntity>().Where(whereExpression).AsNoTracking();

            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            var element = query.FirstOrDefault();

            if (element == null)
            {
                var typeNameAttribute = typeof(TEntity).GetCustomAttribute<TypeNameAttribute>();
                var entityTypeName = typeNameAttribute?.TypeName ?? typeof(TEntity).Name;
                throw new KeyNotFoundException($"Not found object {entityTypeName}");
            }

            return element;
        }
    }
}
