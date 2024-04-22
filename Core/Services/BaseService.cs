using Core.Interfaces.Repository;

namespace Core.Services
{
    public class BaseService<TEntity> where TEntity : class
    {
        public readonly IAdminInterfaces _adminInterfaces;

        public BaseService(IAdminInterfaces adminInterfaces)
        {
            _adminInterfaces = adminInterfaces;
        }
    }
}
