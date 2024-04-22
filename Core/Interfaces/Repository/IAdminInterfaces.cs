using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces.Repository
{
    public interface IAdminInterfaces : IDisposable
    {
        IProductRepository productRepository { get; }
        IOrderProdcutRepository orderProductRepository { get; }
        IOrderRepository orderRepository { get; }
        IPermissionsRepository permissionsRepository { get; }
        IRoleRepository roleRepository { get; }
        IRoleUserRepository roleUserRepository { get; }
        IUserOrderRepository userOrderRepository { get; }
        IUserRepository userRepository { get; }
        IUtilsFunctionsRepository utilsFunctionsRepository { get; }
        ILogExceptionRepository logExceptionRepository { get; }
        IServiceRepository serviceRepository { get; }
        IPermissRolesServicesRepository permissRolesServicesRepository { get; }
        IRolesServicesRepository rolesServicesRepository { get; }

        void saveChange();
        Task saveChangeAsync();
    }
}
