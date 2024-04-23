using System.Linq.Expressions;

namespace Service.Interface
{
    public interface IBaseService<T, TDto> 
        where T : class
        where TDto : class
    {
        TDto Get(int id);
        Task<TDto> GetAsync(int id);
        TDto FirstOrDefault(Expression<Func<T, bool>> predicate = null);
        Task<TDto> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null);
        IEnumerable<TDto> GetAll(Expression<Func<T, bool>> predicate = null);
        int Add(TDto geoPlaceDto);
        Task<int> AddAsync(TDto geoPlaceDto);
        void Update(int id, TDto geoPlaceDto);
        Task UpdateAsync(int id, TDto geoPlaceDto);
        void Remove(int id);
        Task RemoveAsync(int id);
    }
}
