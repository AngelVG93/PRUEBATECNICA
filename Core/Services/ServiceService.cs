using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class ServiceService : BaseService<Service>, IServiceService
    {
        public ServiceService(IAdminInterfaces adminInterfaces) : base(adminInterfaces)
        {
        }

        public Task<bool> Delete(Service entity)
        {
            throw new NotImplementedException();
        }

        public Task<Service> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Service>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Service> Post(Service entity)
        {
            throw new NotImplementedException();
        }

        public Task<Service> Put(Service entity)
        {
            throw new NotImplementedException();
        }
    }
}
