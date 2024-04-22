using Core.Entities;
using Core.Interfaces.Repository;
using Persistence.ContextDB;


namespace Infraestructure.Repositories
{
    public class UserOrderRepository : BaseRepository<UserOrder>, IUserOrderRepository
    {
        public UserOrderRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }
    }
}
