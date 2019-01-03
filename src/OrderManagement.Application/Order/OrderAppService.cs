using OrderManagement.EntityFramework.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Application.Order
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IRepository<Core.Order.Order> _orderRepo;

        public OrderAppService(IRepository<Core.Order.Order> orderRepository)
        {
            _orderRepo = orderRepository;
        }

        public async Task<int> CreateOrderAsync(Core.Order.Order order)
        {
            return await _orderRepo.AddAsync(order);
        }

        public async Task<Core.Order.Order> GetOrderByIdAsync(long Id)
        {
            return await _orderRepo.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<Core.Order.Order>> GetOrdersAsync()
        {
            return await _orderRepo.GetAllAsync();
        }

        public async Task<int> UpdateOrderAsync(Core.Order.Order order)
        {
            return await _orderRepo.UpdateAsync(order);
        }
    }
}
