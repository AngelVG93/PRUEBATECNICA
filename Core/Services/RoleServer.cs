using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;


namespace Core.Services
{
    public class RoleServer : BaseService<Role>, IRoleService
    {
        public RoleServer(IAdminInterfaces adminInterfaces) : base(adminInterfaces)
        {
        }

        public async Task<bool> Delete(Role entity)
        {
           await _adminInterfaces.roleRepository.Delete(entity);
           await _adminInterfaces.saveChangeAsync();
            return true;
        }

        public async Task<Role> Get(int id)
        {
            return await _adminInterfaces.roleRepository.GetById(id);
        }

        public async Task<IEnumerable<Role>> Get()
        {
            return await _adminInterfaces.roleRepository.GetAll();
        }

        public Task<Role> Post(Role entity)
        {
            var alimentaryGroups = _adminInterfaces.roleRepository.Add(entity);
            _adminInterfaces.saveChange();
            return alimentaryGroups;
        }

        public Task<Role> Put(Role entity)
        {
            var alimentaryGroups = _adminInterfaces.roleRepository.UpdateAsync(entity);
            _adminInterfaces.saveChange();
            return alimentaryGroups;
        }
    }
}
