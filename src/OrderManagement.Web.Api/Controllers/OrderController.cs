using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Order;
using OrderManagement.Core.Order;

namespace OrderManagement.Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderAppService _orderService;

        public OrderController(IOrderAppService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _orderService.GetOrdersAsync();
        }

        [HttpGet("{id}")]
        public async Task<Order> Get(long id)
        {
            return await _orderService.GetOrderByIdAsync(id);
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<int> AddOrder(Order order)
        {
            return await _orderService.CreateOrderAsync(order);
        }

        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<int> UpdateOrder(Order order)
        {
            return await _orderService.UpdateOrderAsync(order);
        }

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
