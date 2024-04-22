using Core.Entities;
using Core.Interfaces.Repository;
using Persistence.ContextDB;

namespace Infraestructure.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }
    }
}
