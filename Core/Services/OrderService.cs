using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService(IAdminInterfaces adminInterfaces) : base(adminInterfaces)
        {
        }

        public async Task<bool> Delete(Order entity)
        {
           await _adminInterfaces.orderRepository.Delete(entity);
           await _adminInterfaces.saveChangeAsync();
            return true;
        }

        public async Task<Order> Get(int id)
        {
            return await _adminInterfaces.orderRepository.GetById(id);
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _adminInterfaces.orderRepository.GetAll();
        }

        public Task<Order> Post(Order entity)
        {
            var alimentaryGroups = _adminInterfaces.orderRepository.Add(entity);
            _adminInterfaces.saveChange();
            return alimentaryGroups;
        }

        public Task<Order> Put(Order entity)
        {
            var alimentaryGroups = _adminInterfaces.orderRepository.UpdateAsync(entity);
            _adminInterfaces.saveChange();
            return alimentaryGroups;
        }
    }
}
