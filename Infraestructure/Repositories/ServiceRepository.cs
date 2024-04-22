
using Core.Entities;
using Core.Interfaces.Repository;
using Persistence.ContextDB;

namespace Infraestructure.Repositories
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }
    }
}
