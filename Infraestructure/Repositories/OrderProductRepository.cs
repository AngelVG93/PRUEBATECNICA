using Core.Entities;
using Core.Interfaces.Repository;
using Persistence.ContextDB;


namespace Infraestructure.Repositories
{
    public class OrderProductRepository : BaseRepository<OrderProduct>, IOrderProdcutRepository
    {
        public OrderProductRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }
    }
}
