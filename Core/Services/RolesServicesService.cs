using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class RolesServicesService : BaseService<RolesServices>, IRolesServicesService
    {
        public RolesServicesService(IAdminInterfaces adminInterfaces) : base(adminInterfaces)
        {
        }

        public async Task<bool> Delete(RolesServices entity)
        {
            await _adminInterfaces.rolesServicesRepository.Delete(entity);
            await _adminInterfaces.saveChangeAsync();
            return true;
        }

        public async Task<RolesServices> Get(int id)
        {
            return await _adminInterfaces.rolesServicesRepository.GetById(id);
        }

        public async Task<IEnumerable<RolesServices>> Get()
        {
            return await _adminInterfaces.rolesServicesRepository.GetAll();
        }

        public async Task<RolesServices> Post(RolesServices entity)
        {
            var rolesServices = await _adminInterfaces.rolesServicesRepository.Add(entity);
            await _adminInterfaces.saveChangeAsync();
            return rolesServices;
        }

        public async Task<RolesServices> Put(RolesServices entity)
        {
            var alimentaryGroups = await _adminInterfaces.rolesServicesRepository.UpdateAsync(entity);
            await _adminInterfaces.saveChangeAsync();
            return alimentaryGroups;
        }
    }
}
