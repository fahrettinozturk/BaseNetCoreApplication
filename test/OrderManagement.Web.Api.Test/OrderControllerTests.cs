using NUnit.Framework;
using OrderManagement.Application.Order;
using OrderManagement.EntityFramework.Repositories;
using OrderManagement.Test.Shared;
using OrderManagement.Web.Api.Controllers;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class OrderControllerTests : TestBase
    {
        private OrderController orderController;

        [SetUp]
        public void Setup()
        {
            var orderRepository = new Repository<OrderManagement.Core.Order.Order>(OrderManagementInMemoryDbContext);
            IOrderAppService _orderAppService = new OrderAppService(orderRepository);

            orderController = new OrderController(_orderAppService);
        }

        [Test]
        public void OrderController_WhenCalled_AddOrder()
        {
            OrderManagement.Core.Order.Order newOrder = new OrderManagement.Core.Order.Order();

            var result = orderController.AddOrder(newOrder).Result;

            Assert.AreEqual(1, result);
        }

        [Test]
        public void OrderConotroller_WhenCalled_ReturnOrders()
        {
            OrderManagement.Core.Order.Order newOrder = new OrderManagement.Core.Order.Order();
            orderController.AddOrder(newOrder).Wait();

            IEnumerable<OrderManagement.Core.Order.Order> result = orderController.Get().Result;

            Assert.IsTrue(result.Count() > 0);
        }

        [Test]
        public void OrderController_WhenCalled_ReturnSpecificOrder()
        {
            OrderManagement.Core.Order.Order newOrder = new OrderManagement.Core.Order.Order();
            orderController.AddOrder(newOrder).Wait();

            OrderManagement.Core.Order.Order result = orderController.Get(newOrder.Id).Result;

            Assert.AreEqual(newOrder.Id, result.Id);
        }

        [Test]
        public void OrderController_WhenCalled_UpdateOrder()
        {
            OrderManagement.Core.Order.Order newOrder = new OrderManagement.Core.Order.Order();
            orderController.AddOrder(newOrder).Wait();
            newOrder.Address = "New Address";
            orderController.UpdateOrder(newOrder).Wait();
            OrderManagement.Core.Order.Order result = orderController.Get(newOrder.Id).Result;

            Assert.AreEqual(newOrder.Address, result.Address);
        }
    }
}