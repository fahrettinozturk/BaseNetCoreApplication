using OrderManagement.EntityFramework.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Application.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IRepository<Core.Product.Product> _productRepo;

        public ProductAppService(IRepository<Core.Product.Product> productRepository)
        {
            _productRepo = productRepository;
        }

        public async Task<int> CreateProductAsync(Core.Product.Product product)
        {
            return await _productRepo.AddAsync(product);
        }

        public async Task<Core.Product.Product> GetProductByIdAsync(long Id)
        {
            return await _productRepo.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<Core.Product.Product>> GetProductsAsync()
        {
            return await _productRepo.GetAllAsync();
        }

        public async Task<int> UpdateProductAsync(Core.Product.Product product)
        {
            return await _productRepo.UpdateAsync(product);
        }
    }
}
