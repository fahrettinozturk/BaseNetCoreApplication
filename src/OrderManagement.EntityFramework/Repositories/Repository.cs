using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrderManagement.EntityFramework.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly OrderManagementDbContext DbContext;
        private readonly DbSet<TEntity> DbSet;

        public Repository(OrderManagementDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<int> AddAsync(TEntity obj)
        {
            if (obj != null)
            {
                DbSet.Add(obj);
                return await DbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet.Where(expression).ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<int> RemoveAsync(long id)
        {
            var obj = DbSet.Find(id);
            DbSet.Remove(obj);
            return await DbContext.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync(TEntity obj)
        {
            DbSet.Update(obj);
            return await DbContext.SaveChangesAsync();
        }
    }
}
