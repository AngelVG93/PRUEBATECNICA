using Core.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.ContextDB;

namespace Infraestructure.Repositories
{
    public class AdminInterfaces : IAdminInterfaces
    {
        public pruebatecnicaDbContext _context;
        public IConfiguration _configuration;
        public AdminInterfaces(pruebatecnicaDbContext context,
                               IServiceScopeFactory serviceScopeFactory,
                               IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        
        private readonly IProductRepository? _productRepository;
        private readonly IOrderProdcutRepository? _orderFoodRepository;
        private readonly IOrderRepository? _orderRepository;
        private readonly IPermissionsRepository? _permissionsRepository;
        private readonly IRoleRepository? _roleRepository;
        private readonly IRoleUserRepository? _roleUserRepository;
        private readonly IUserOrderRepository? _userOrderRepository;
        private readonly IUserRepository? _userRepository;
        private readonly IUtilsFunctionsRepository? _utilsFunctionsRepository;
        private readonly ILogExceptionRepository? _logExceptionRepository;
        private readonly IServiceRepository? _serviceRepository;
        private readonly IPermissRolesServicesRepository? _permissRolesServicesRepository;
        private readonly IRolesServicesRepository? _rolesServicesRepository;


        public IProductRepository productRepository => _productRepository ?? new ProductRepository(_context);


        public IOrderProdcutRepository orderProductRepository => _orderFoodRepository ?? new OrderProductRepository(_context);

        public IOrderRepository orderRepository => _orderRepository ?? new OrderRepository(_context);

        public IPermissionsRepository permissionsRepository => _permissionsRepository ?? new PermissionsRepository(_context);


        public IRoleRepository roleRepository => _roleRepository ?? new RoleRepository(_context);

        public IRoleUserRepository roleUserRepository => _roleUserRepository ?? new RoleUserRepository(_context);

        public IUserOrderRepository userOrderRepository => _userOrderRepository ?? new UserOrderRepository(_context);

        public IUserRepository userRepository => _userRepository ?? new UserRepository(_context);

        public IUtilsFunctionsRepository utilsFunctionsRepository => _utilsFunctionsRepository ?? new UtilsFunctionsRepository(_configuration);

        public ILogExceptionRepository logExceptionRepository => _logExceptionRepository ?? new LogExceptionRepository(_context);

        public IServiceRepository serviceRepository => _serviceRepository ?? new ServiceRepository(_context);

        public IPermissRolesServicesRepository permissRolesServicesRepository => _permissRolesServicesRepository ?? new PermissRolesServicesRepository(_context);

        public IRolesServicesRepository rolesServicesRepository => _rolesServicesRepository ?? new RolesServicesRepository(_context);   

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void saveChange()
        {
            _context.SaveChanges();
        }

        public async Task saveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
