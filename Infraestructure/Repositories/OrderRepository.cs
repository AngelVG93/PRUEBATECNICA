using Core.Entities;
using Core.Interfaces.Repository;
using Persistence.ContextDB;


namespace Infraestructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }
    }
}
