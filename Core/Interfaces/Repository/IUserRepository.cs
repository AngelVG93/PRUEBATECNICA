using Core.Entities;

namespace Core.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> validatePermissions(int idUser, int idPermission, string nameService);
        Task<User> GetUserLogin(string nameUser, string password);
        Task<User> GetInfoServicePermiss(int id);
    }
}
