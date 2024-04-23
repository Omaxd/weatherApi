using AutoMapper;
using Data.Interface;
using System.Linq.Expressions;

namespace Service
{
    public abstract class BaseService<T, TDto>
        where T : class
        where TDto : class
    {
        protected readonly IMapper mapper;
        protected readonly IBaseRepository<T> baseRepository;

        public BaseService(IMapper mapper, IBaseRepository<T> baseRepository)
        {
            this.mapper = mapper;
            this.baseRepository = baseRepository;
        }

        public virtual TDto Get(int id)
        {
            var result = baseRepository.Get(id);

            return mapper.Map<TDto>(result);
        }

        public async virtual Task<TDto> GetAsync(int id)
        {
            var result = await baseRepository.GetAsync(id);

            return mapper.Map<TDto>(result);
        }

        public virtual TDto FirstOrDefault(Expression<Func<T, bool>> predicate = null)
        {
            var result = baseRepository.FirstOrDefault(predicate);

            return mapper.Map<TDto>(result);
        }

        public async virtual Task<TDto> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null)
        {
            var result = await baseRepository.FirstOrDefaultAsync(predicate);

            return mapper.Map<TDto>(result);
        }

        public virtual IEnumerable<TDto> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            var result = baseRepository.GetAll(predicate).AsEnumerable();

            return mapper.Map<IEnumerable<TDto>>(result);
        }

        public virtual int Add(TDto geoPlaceDto)
        {
            var newItem = mapper.Map<T>(geoPlaceDto);

            return baseRepository.Add(newItem);
        }

        public async virtual Task<int> AddAsync(TDto geoPlaceDto)
        {
            var newItem = mapper.Map<T>(geoPlaceDto);

            return await baseRepository.AddAsync(newItem);
        }

        public virtual void Update(int id, TDto geoPlaceDto)
        {
            var updatedItem = mapper.Map<T>(geoPlaceDto);

            baseRepository.Update(id, updatedItem);
        }

        public async virtual Task UpdateAsync(int id, TDto geoPlaceDto)
        {
            var updatedItem = mapper.Map<T>(geoPlaceDto);

            await baseRepository.UpdateAsync(id, updatedItem);
        }

        public virtual void Remove(int id)
        {
            baseRepository.Remove(id);
        }

        public async virtual Task RemoveAsync(int id)
        {
            await baseRepository.RemoveAsync(id);
        }
    }
}
