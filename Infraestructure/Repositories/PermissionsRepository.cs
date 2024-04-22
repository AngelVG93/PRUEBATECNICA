using Core.Entities;
using Core.Interfaces.Repository;
using Persistence.ContextDB;


namespace Infraestructure.Repositories
{
    public class PermissionsRepository : BaseRepository<Permissions>, IPermissionsRepository
    {
        public PermissionsRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }
    }
}
