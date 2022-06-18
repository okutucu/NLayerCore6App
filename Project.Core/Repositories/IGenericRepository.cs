using System.Linq.Expressions;
using Project.Core.Models;

namespace Project.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll(Expression<Func<T, bool>> exp);
        // IQueryable<T> kullandığımız için ;
        // productRepository.Where(x=> x.id>5) -> buraya kadar daha veri tabanına gitmedi.
        // productRepository.Where(x=> x.id>5).OrderBy.ToListAsync() dediğimiz anda dbye sorgu yapacağı için daha performanslı olacaktır.
        IQueryable<T> Where(Expression<Func<T,bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        IQueryable<T> FirstOrDefault(Expression<Func<T, bool>> exp);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Destroy(T entity);
        void DestroyRange(IEnumerable<T> entities);

    }
}
