using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesignPatterns.Repository.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(
       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
       Expression<Func<T, T>> select = null,
       string includeProperties = null,
       int? skip = null,
       int? take = null);

        Task<IEnumerable<T>> GetAllAsync(
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, T>> select = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null);


        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, T>> select = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null);


        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, T>> select = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null);


        T GetOne(
           Expression<Func<T, bool>> filter = null,
           Expression<Func<T, T>> select = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "");

        Task<T> GetOneAsync(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, T>> select = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);

        T GetById(object id);

        Task<T> GetByIdAsync(object id);

        void Add(T entity);

        void CreateInRange(List<T> entities);

        void Update(T entity);

        void Delete(object id);

        void Delete(T entity);

        int GetKey(T entity);

        Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null);

        Task SaveChanges();
    }
}
