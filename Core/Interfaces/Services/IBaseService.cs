using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IBaseService<TEntity>
    {
        Task<bool> Delete(TEntity entity);
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> Post(TEntity entity);
        Task<TEntity> Put(TEntity entity);
    }
}
