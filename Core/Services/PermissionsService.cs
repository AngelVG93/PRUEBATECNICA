using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PermissionsService : BaseService<Permissions>, IPermissionsService
    {
        public PermissionsService(IAdminInterfaces adminInterfaces) : base(adminInterfaces)
        {
        }

        public async Task<bool> Delete(Permissions entity)
        {
           await _adminInterfaces.permissionsRepository.Delete(entity);
           await _adminInterfaces.saveChangeAsync();
            return true;
        }

        public async Task<Permissions> Get(int id)
        {
            return await _adminInterfaces.permissionsRepository.GetById(id);
        }

        public async Task<IEnumerable<Permissions>> Get()
        {
            return await _adminInterfaces.permissionsRepository.GetAll();
        }

        public Task<Permissions> Post(Permissions entity)
        {
            var alimentaryGroups = _adminInterfaces.permissionsRepository.Add(entity);
            _adminInterfaces.saveChange();
            return alimentaryGroups;
        }

        public Task<Permissions> Put(Permissions entity)
        {
            var alimentaryGroups = _adminInterfaces.permissionsRepository.UpdateAsync(entity);
            _adminInterfaces.saveChange();
            return alimentaryGroups;
        }
    }
}
