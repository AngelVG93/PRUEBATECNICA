using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.ContextDB;

namespace Infraestructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }

        public async Task<User> GetInfoServicePermiss(int id)
        {
            var data = await _entities
                .Include(x => x.RoleUser)
                .ThenInclude(x => x.IdRoleNavigation)
                .ThenInclude(x => x.RolesServices)
                .ThenInclude(x => x.IdServiceNavigation)
                .ThenInclude(x => x.RolesServices)
                .ThenInclude(x => x.PermissRolesServices)
                .ThenInclude(x => x.IdPermissionsNavigation)
                .Where(x => x.id == id)
                .FirstOrDefaultAsync();
            return data;
        }

        public async Task<User> GetUserLogin(string usernumber, string password)
        {
            try
            {
               return await _entities.Where(x => x.IdentityNumber.Equals(usernumber) 
                                            && x.Password.Equals(password))
                .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                LogException logException = new LogException();
                logException.Message = $"Data consult error : {e.Message}";
                logException.Name = "Internal Server Error in UserRepository funtion validatePermissions";

                InternalServerErrorBusinessExceprions ex = new InternalServerErrorBusinessExceprions(logException);
                throw ex;
            }
        }

        public async Task<bool> validatePermissions(int idUser, int idPermission,string nameService)
        {
            User user = new User();
            try
            {
                user = await _entities
                .Include(x => x.RoleUser)
                .ThenInclude(rol => rol.IdRoleNavigation)
                .Where(x => x.id == idUser 
                    && x.RoleUser.Any(x => x.IdRoleNavigation.RolesServices.Any(x => x.PermissRolesServices.Any(x => x.IdPermissions == idPermission)))
                    && x.RoleUser.Any(x => x.IdRoleNavigation.RolesServices.Any(x => x.IdServiceNavigation.NameService.Equals(nameService))))
                .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                LogException logException = new LogException();
                logException.Message = $"Data consult error : {e.Message}";
                logException.Name = "Internal Server Error in UserRepository funtion validatePermissions";

                InternalServerErrorBusinessExceprions ex = new InternalServerErrorBusinessExceprions(logException);
                throw ex;
            }
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
