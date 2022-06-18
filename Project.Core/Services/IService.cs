using System.Linq.Expressions;
using Project.Core.Models;

namespace Project.Core.Services
{
    public interface IService<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
  
    }
}
