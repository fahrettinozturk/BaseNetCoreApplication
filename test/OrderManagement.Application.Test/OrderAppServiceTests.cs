using NUnit.Framework;
using OrderManagement.Application.Order;
using OrderManagement.EntityFramework.Repositories;
using OrderManagement.Test.Shared;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestFixture]
    public class OrderAppServiceTestsv : TestBase
    {
        private IOrderAppService _orderService;

        [SetUp]
        public void Setup()
        {
            var orderRepository = new Repository<OrderManagement.Core.Order.Order>(OrderManagementInMemoryDbContext);
            _orderService = new OrderAppService(orderRepository);
        }

        [Test]
        public void OrderAppService_WhenCalled_ReturnAllOrders()
        {
            OrderManagement.Core.Order.Order newOrder = new OrderManagement.Core.Order.Order
            { Address = "Address1", OrderDate = DateTime.Now, OrderTotal = 1, ProductId = 1, SystemDate = DateTime.Now };

            _orderService.CreateOrderAsync(newOrder);

            IEnumerable<OrderManagement.Core.Order.Order> orderList = _orderService.GetOrdersAsync().Result;

            Assert.True(orderList.Count() > 0);
        }

        [Test]
        public void OrderAppService_WhenCalled_AddOrder()
        {
            OrderManagement.Core.Order.Order newOrder = new OrderManagement.Core.Order.Order
            { Address = "Address", OrderDate = DateTime.Now, OrderTotal = 1, ProductId = 1, SystemDate = DateTime.Now };

            var result = _orderService.CreateOrderAsync(newOrder);

            Assert.AreEqual(1, result.Result);
        }

        [Test]
        public void OrderAppService_WhenCalledWithId_ReturnSpecificOrder()
        {
            OrderManagement.Core.Order.Order newOrder = new OrderManagement.Core.Order.Order
            {Id = 99, Address = "Address", OrderDate = DateTime.Now, OrderTotal = 1, ProductId = 1, SystemDate = DateTime.Now };

            _orderService.CreateOrderAsync(newOrder);

            OrderManagement.Core.Order.Order order = _orderService.GetOrderByIdAsync(newOrder.Id).Result;

            Assert.AreEqual(99, order.Id);

        }

        [Test]
        public void OrderAppService_WhenCalled_UpdateSpecificOrder()
        {
            OrderManagement.Core.Order.Order newOrder = new OrderManagement.Core.Order.Order
            { Id = 99, Address = "Address", OrderDate = DateTime.Now, OrderTotal = 1, ProductId = 1, SystemDate = DateTime.Now };

            _orderService.CreateOrderAsync(newOrder);

            newOrder.Address = "New Address";

            _orderService.UpdateOrderAsync(newOrder);

            OrderManagement.Core.Order.Order order = _orderService.GetOrderByIdAsync(newOrder.Id).Result;

            Assert.AreEqual("New Address", order.Address);
        }
    }
}