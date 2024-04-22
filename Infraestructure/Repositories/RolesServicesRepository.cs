
using Core.Entities;
using Core.Interfaces.Repository;
using Persistence.ContextDB;

namespace Infraestructure.Repositories
{
    public class RolesServicesRepository : BaseRepository<RolesServices>, IRolesServicesRepository
    {
        public RolesServicesRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }
    }
}
