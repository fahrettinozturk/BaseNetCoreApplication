using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Application.Product
{
    public interface IProductAppService
    {
        Task<Core.Product.Product> GetProductByIdAsync(long Id);
        Task<IEnumerable<Core.Product.Product>> GetProductsAsync();
        Task<int> CreateProductAsync(Core.Product.Product product);
        Task<int> UpdateProductAsync(Core.Product.Product product);
    }
}
