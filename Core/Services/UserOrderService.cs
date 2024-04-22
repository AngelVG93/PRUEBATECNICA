using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class UserOrderService : BaseService<UserOrder>, IUserOrderService
    {
        public UserOrderService(IAdminInterfaces adminInterfaces) : base(adminInterfaces)
        {
        }

        public async Task<bool> Delete(UserOrder entity)
        {
          await  _adminInterfaces.userOrderRepository.Delete(entity);
           await _adminInterfaces.saveChangeAsync();
            return true;
        }

        public async Task<UserOrder> Get(int id)
        {
            return await _adminInterfaces.userOrderRepository.GetById(id);
        }

        public async Task<IEnumerable<UserOrder>> Get()
        {
            return await _adminInterfaces.userOrderRepository.GetAll();
        }

        public Task<UserOrder> Post(UserOrder entity)
        {
            var alimentaryGroups = _adminInterfaces.userOrderRepository.Add(entity);
            _adminInterfaces.saveChange();
            return alimentaryGroups;
        }

        public Task<UserOrder> Put(UserOrder entity)
        {
            var alimentaryGroups = _adminInterfaces.userOrderRepository.UpdateAsync(entity);
            _adminInterfaces.saveChange();
            return alimentaryGroups;
        }
    }
}
