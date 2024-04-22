using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IAdminInterfaces adminInterfaces) : base(adminInterfaces)
        {
        }

        public async Task<bool> Delete(Product entity)
        {
            await _adminInterfaces.productRepository.Delete(entity);
           await _adminInterfaces.saveChangeAsync();
            return true;
        }

        public async Task<Product> Get(int id)
        {
            return await _adminInterfaces.productRepository.GetById(id);
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return  await _adminInterfaces.productRepository.GetAll();
        }

        public Task<Product> Post(Product entity)
        {
            var alimentaryGroups = _adminInterfaces.productRepository.Add(entity);
            _adminInterfaces.saveChange();
            return alimentaryGroups; 
        }

        public Task<Product> Put(Product entity)
        {
            var alimentaryGroups = _adminInterfaces.productRepository.UpdateAsync(entity);
            _adminInterfaces.saveChange();
            return alimentaryGroups;
        }
    }
}
