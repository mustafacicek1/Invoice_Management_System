using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly DbContext _context;
        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return query.SingleOrDefault();

        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }

            return query.ToList();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
