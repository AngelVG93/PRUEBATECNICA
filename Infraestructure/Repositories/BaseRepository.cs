using Core.Entities;
using Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.ContextDB;


namespace Infraestructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly pruebatecnicaDbContext _contex;
        protected readonly DbSet<T> _entities;
        public BaseRepository(pruebatecnicaDbContext contex)
        {
            _contex = contex;
            _entities = contex.Set<T>();
        }
        public virtual async Task<T> Add(T entity)
        {
            try
            {
                var result = await _entities.AddAsync(entity);
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual Task AddRange(List<T> entity)
        {
            try
            {
                return _entities.AddRangeAsync(entity); ;
            }
            catch (NotSupportedException)
            {
 
                throw;
            }
        }

        public virtual Task<bool> Delete(T entity)
        {
            try
            {
                _entities.Remove(entity);
                return Task.FromResult(true); 
            }
            catch (NotSupportedException)
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _entities.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public virtual async Task<T> GetById(int id)
        {
            T? t = await _entities.FindAsync(id);
            return t;
        }

        public virtual Task<T> UpdateAsync(T entity)
        {
            return Task.FromResult(_entities.Update(entity).Entity);
        }
    }
}
