using DesignPatterns.Repository.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesignPatterns.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly PostsDbContext _context;

        public GenericRepository(PostsDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void CreateInRange(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void Delete(object id)
        {
            T entity = _context.Set<T>().Find(id);
            Delete(entity);
        }

        public void Delete(T entity)
        {
            var dbSet = _context.Set<T>();
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Expression<Func<T, T>> select = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            return GetQueryable(filter, select, orderBy, includeProperties, skip, take).ToList();
        }

        public IEnumerable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, T>> select = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            return GetQueryable(null, select, orderBy, includeProperties, skip, take).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, T>> select = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            return await GetQueryable(null, select, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, Expression<Func<T, T>> select = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            return await GetQueryable(filter, select, orderBy, includeProperties, skip, take).AsNoTracking().ToListAsync();
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T GetOne(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, T>> select = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null)
        {
            return GetQueryable(filter, select, orderBy, includeProperties).FirstOrDefault();
        }

        public async Task<T> GetOneAsync(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, T>> select = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null)
        {
            return await GetQueryable(filter, select, orderBy, includeProperties).FirstOrDefaultAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
      Expression<Func<TEntity, bool>> filter = null,
      Expression<Func<TEntity, TEntity>> select = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = null,
      int? skip = null,
      int? take = null)
      where TEntity : class
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (select != null)
            {
                query = query.Select(select);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public virtual int GetKey(T entity)
        {
            var keyName = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties
                .Select(x => x.Name).Single();

            return (int)entity.GetType().GetProperty(keyName).GetValue(entity, null);
        }

        public Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null)
        {
            return GetQueryable(filter).CountAsync();
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
