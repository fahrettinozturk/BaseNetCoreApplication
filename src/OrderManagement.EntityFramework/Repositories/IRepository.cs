using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.EntityFramework.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> AddAsync(TEntity obj);
        Task<IEnumerable<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetByIdAsync(long id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<int> RemoveAsync(long id);
        Task<int> UpdateAsync(TEntity obj);
    }
}
