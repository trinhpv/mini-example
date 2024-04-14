using MiniExample.Utility.Filter;
using System.Linq.Expressions;

namespace MiniExample.Data.Repositories.Interfaces
{
   
        public interface IGenericRepository<T> where T : class
        {
            Task<IEnumerable<T>> GetAll();
            Task<T> GetById(int id);
            Task<T?> GetByIdAsync(int id);
            Task Insert(T obj);
            Task Update(T obj);
            Task Delete(int id);
            Task<IEnumerable<T>> Get(
                Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string includeProperties = "", PaginationFilter paginateData = null);
            Task<int> Count(Expression<Func<T, bool>> filter = null);
        }
    }

