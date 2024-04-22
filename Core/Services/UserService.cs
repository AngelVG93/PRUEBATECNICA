using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IAdminInterfaces adminInterfaces) : base(adminInterfaces)
        {
        }

        public async Task<bool> Delete(User entity)
        {
           await _adminInterfaces.userRepository.Delete(entity);
           await _adminInterfaces.saveChangeAsync();
            return true;
        }

        public async Task<User> Get(int id)
        {
            return await _adminInterfaces.userRepository.GetById(id);
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _adminInterfaces.userRepository.GetAll();
        }

        public async Task<User> GetInfoServicePermiss(int id)
        {
            return await _adminInterfaces.userRepository.GetInfoServicePermiss(id);
        }

        public async Task<User> Post(User entity)
        {
            entity.Password = _adminInterfaces.utilsFunctionsRepository.DecodeMd5(entity.Password);
            var alimentaryGroups = await _adminInterfaces.userRepository.Add(entity);
            _adminInterfaces.saveChange();
            alimentaryGroups.Password = "";
            return alimentaryGroups;
        }

        public async Task<User> Put(User entity)
        {
            var alimentaryGroups = await _adminInterfaces.userRepository.UpdateAsync(entity);
            _adminInterfaces.saveChange();
            alimentaryGroups.Password = "";
            return alimentaryGroups;
        }
    }
}
