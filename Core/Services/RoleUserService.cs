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
    public class RoleUserService : BaseService<RoleUser>, IRoleUserService
    {
        public RoleUserService(IAdminInterfaces adminInterfaces) : base(adminInterfaces)
        {
        }

        public async Task<bool> Delete(RoleUser entity)
        {
           await _adminInterfaces.roleUserRepository.Delete(entity);
           await _adminInterfaces.saveChangeAsync();
            return true;
        }

        public async Task<RoleUser> Get(int id)
        {
            return await _adminInterfaces.roleUserRepository.GetById(id);
        }

        public async Task<IEnumerable<RoleUser>> Get()
        {
            return  await _adminInterfaces.roleUserRepository.GetAll();
        }

        public Task<RoleUser> Post(RoleUser entity)
        {
            var alimentaryGroups = _adminInterfaces.roleUserRepository.Add(entity);
            _adminInterfaces.saveChange();
            return alimentaryGroups;
        }

        public Task<RoleUser> Put(RoleUser entity)
        {
            var alimentaryGroups = _adminInterfaces.roleUserRepository.UpdateAsync(entity);
            _adminInterfaces.saveChange();
            return alimentaryGroups;
        }
    }
}
