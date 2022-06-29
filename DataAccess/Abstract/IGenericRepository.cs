using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IGenericRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);
        T Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
