
using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class PermissRolesServicesService : BaseService<PermissRolesServices>, IPermissRolesServicesService
    {
        public PermissRolesServicesService(IAdminInterfaces adminInterfaces) : base(adminInterfaces)
        {
        }

        public async Task<bool> Delete(PermissRolesServices entity)
        {
            await _adminInterfaces.permissRolesServicesRepository.Delete(entity);
            await _adminInterfaces.saveChangeAsync();
            return true;
        }

        public async Task<PermissRolesServices> Get(int id)
        {
            return await _adminInterfaces.permissRolesServicesRepository.GetById(id);
        }

        public async Task<IEnumerable<PermissRolesServices>> Get()
        {
            return await _adminInterfaces.permissRolesServicesRepository.GetAll();
        }

        public async Task<PermissRolesServices> Post(PermissRolesServices entity)
        {
            var rolesServices = await _adminInterfaces.permissRolesServicesRepository.Add(entity);
            await _adminInterfaces.saveChangeAsync();
            return rolesServices;
        }

        public async Task<PermissRolesServices> Put(PermissRolesServices entity)
        {
            var alimentaryGroups = await _adminInterfaces.permissRolesServicesRepository.UpdateAsync(entity);
            await _adminInterfaces.saveChangeAsync();
            return alimentaryGroups;
        }
    }
}
