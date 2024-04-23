using System.Linq.Expressions;

namespace Data.Interface
{
    public interface IBaseRepository<T> 
        where T : class
    {
        T? Get(int id);
        Task<T?> GetAsync(int id);
        T? FirstOrDefault(Expression<Func<T, bool>> predicate = null);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        int Add(T item);
        Task<int> AddAsync(T item);
        void Update(int id, T item);
        Task UpdateAsync(int id, T item);
        void Remove(int id);
        Task RemoveAsync(int id);
    }
}
