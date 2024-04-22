using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class OrderProductService : BaseService<OrderProduct>, IOrderProductService
    {
        public OrderProductService(IAdminInterfaces adminInterfaces) : base(adminInterfaces)
        {
        }

        public async Task<bool> Delete(OrderProduct entity)
        {
           await _adminInterfaces.orderProductRepository.Delete(entity);
           await _adminInterfaces.saveChangeAsync();
            return true;
        }

        public async Task<OrderProduct> Get(int id)
        {
            return await _adminInterfaces.orderProductRepository.GetById(id);
        }

        public async Task<IEnumerable<OrderProduct>> Get()
        {
            return await _adminInterfaces.orderProductRepository.GetAll();
        }

        public Task<OrderProduct> Post(OrderProduct entity)
        {
            var alimentaryGroups = _adminInterfaces.orderProductRepository.Add(entity);
            _adminInterfaces.saveChange();
            return alimentaryGroups;
        }

        public Task<OrderProduct> Put(OrderProduct entity)
        {
            var alimentaryGroups = _adminInterfaces.orderProductRepository.UpdateAsync(entity);
            _adminInterfaces.saveChange();
            return alimentaryGroups;
        }
    }
}
