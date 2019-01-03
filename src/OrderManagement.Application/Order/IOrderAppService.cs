using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Application.Order
{
    public interface IOrderAppService
    {
        Task<Core.Order.Order> GetOrderByIdAsync(long Id);
        Task<IEnumerable<Core.Order.Order>> GetOrdersAsync();
        Task<int> UpdateOrderAsync(Core.Order.Order order);
        Task<int> CreateOrderAsync(Core.Order.Order order);
    }
}
