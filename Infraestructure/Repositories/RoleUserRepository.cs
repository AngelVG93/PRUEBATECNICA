using Core.Entities;
using Core.Interfaces.Repository;
using Persistence.ContextDB;


namespace Infraestructure.Repositories
{
    public class RoleUserRepository : BaseRepository<RoleUser>, IRoleUserRepository
    {
        public RoleUserRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }
    }
}
