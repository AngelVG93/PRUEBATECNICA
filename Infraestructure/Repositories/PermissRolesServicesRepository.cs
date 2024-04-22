using Core.Entities;
using Core.Interfaces.Repository;
using Persistence.ContextDB;

namespace Infraestructure.Repositories
{
    public class PermissRolesServicesRepository : BaseRepository<PermissRolesServices>, IPermissRolesServicesRepository
    {
        public PermissRolesServicesRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }
    }
}
