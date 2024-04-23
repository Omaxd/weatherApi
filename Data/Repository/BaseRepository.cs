using Data.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected readonly WeatherContext weatherContext;

        public BaseRepository(WeatherContext weatherContext)
        {
            this.weatherContext = weatherContext;
        }

        public virtual T? Get(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return weatherContext.Set<T>().Find(id);
        }
        
        public async virtual Task<T?> GetAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return await weatherContext.Set<T>().FindAsync(id);
        }
        public virtual T? FirstOrDefault(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return weatherContext.Set<T>().FirstOrDefault();
            }

            return weatherContext.Set<T>().FirstOrDefault(predicate);
        }

        public async virtual Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await weatherContext.Set<T>().FirstOrDefaultAsync();
            }

            return await weatherContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return weatherContext.Set<T>()
                    .AsQueryable();
            }

            return weatherContext.Set<T>()
                .Where(predicate)
                .AsQueryable();
        }

        public virtual int Add(T item)
        {
            if (item == null)
            {
                return 0;
            }    

            weatherContext.Set<T>().Add(item);
            weatherContext.SaveChanges();

            var id = item.GetType().GetProperty("Id");

            if (id != null)
            {
                return (int)id.GetValue(item);
            }

            return 0;
        }

        public virtual async Task<int> AddAsync(T item)
        {
            if (item == null)
            {
                return await Task.FromResult(0);
            }

            await weatherContext.Set<T>().AddAsync(item);
            await weatherContext.SaveChangesAsync();

            var id = item.GetType().GetProperty("Id");

            if (id != null)
            {
                var idValue = (int)id.GetValue(item);

                return await Task.FromResult(idValue);
            }

            return 0;
        }

        public virtual void Update(int id, T item)
        {
            if (id <= 0 || item == null)
            {
                return;
            }

            var existingItem = weatherContext.Set<T>().Find(id);

            foreach (var property in typeof(T).GetProperties())
            {
                if (property.Name != "Id")
                {
                    property.SetValue(existingItem, property.GetValue(item));
                }
            }

            weatherContext.SaveChanges();
        }

        public virtual async Task UpdateAsync(int id, T item)
        {
            if (id <= 0 || item == null)
            {
                return;
            }

            var existingItem = await weatherContext.Set<T>().FindAsync(id);

            foreach (var property in typeof(T).GetProperties())
            {
                if (property.Name != "Id")
                {
                    property.SetValue(existingItem, property.GetValue(item));
                }
            }

            await weatherContext.SaveChangesAsync();
        }

        public virtual void Remove(int id)
        {
            if (id <= 0)
            {
                return;
            }

            var existingItem = weatherContext.Set<T>().Find(id);

            if (existingItem == null)
            {
                return;
            }

            weatherContext.Remove(existingItem);
            weatherContext.SaveChanges();
        }

        public virtual async Task RemoveAsync(int id)
        {
            if (id <= 0)
            {
                return;
            }

            var existingItem = await weatherContext.Set<T>().FindAsync(id);

            if (existingItem == null)
            {
                return;
            }

            weatherContext.Remove(existingItem);
            await weatherContext.SaveChangesAsync();
        }
    }
}
