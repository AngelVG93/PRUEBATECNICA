using Core.Entities;
using Core.Interfaces.Repository;
using Persistence.ContextDB;

namespace Infraestructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }
    }
}
