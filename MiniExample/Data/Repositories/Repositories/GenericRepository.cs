using Microsoft.EntityFrameworkCore;
using MiniExample.Data.Repositories.Interfaces;
using MiniExample.Utility.Filter;
using System.Linq.Expressions;
using MiniExample.Data.Datacontext;

namespace MiniExample.Data.Repositories.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected MiniContext Context = null;
        protected DbSet<T> Table = null;


        public GenericRepository(MiniContext _context)
        {
            this.Context = _context;
            Table = _context.Set<T>();
        }
        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return  Table.ToList();
        }

        public async virtual Task<T> GetById(int id)
        {
            return Table.Find(id);
        }
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }
        public virtual async Task Insert(T obj)
        {
            Table.Add(obj);
            Context.SaveChanges();
        }
        public virtual async Task Update(T obj)
        {
            Table.Update(obj);
            Context.SaveChanges();
        }
        public virtual async Task Delete(int id)
        {
            T existing = Table.Find(id);
            Table.Remove(existing);
            Context.SaveChanges();
        }

        public async virtual Task<int> Count(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = Table;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.CountAsync();
        }
        public async virtual Task<IEnumerable<T>> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", PaginationFilter paginateData = null)
        {
            IQueryable<T> query = Table;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (paginateData != null)
            {
                if (orderBy != null)
                {
                    return await orderBy(query).Skip((paginateData.PageNumber - 1) * paginateData.PageSize).Take(paginateData.PageSize).ToListAsync();
                }
                else
                {
                    return await query.Skip((paginateData.PageNumber - 1) * paginateData.PageSize).Take(paginateData.PageSize).ToListAsync();
                }
            }
            else
            {
                if (orderBy != null)
                {
                    return await orderBy(query).ToListAsync();
                }
                else
                {
                    return await query.ToListAsync();
                }
            }

        }




    }
}
