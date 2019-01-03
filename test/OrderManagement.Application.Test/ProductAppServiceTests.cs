using NUnit.Framework;
using OrderManagement.Application.Product;
using OrderManagement.EntityFramework.Repositories;
using OrderManagement.Test.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Application.Test
{
    [TestFixture]
    public class ProductAppServiceTests : TestBase
    {
        private IProductAppService _productService;

        [SetUp]
        public void SetUp()
        {
            var productServiceRepo = new Repository<Core.Product.Product>(OrderManagementInMemoryDbContext);
            _productService = new ProductAppService(productServiceRepo);
        }

        [Test]
        public void ProductAppService_WhenCalled_StoreProduct()
        {
            Core.Product.Product newProduct = new Core.Product.Product() {Name = "Name", Price = 1, SystemDate = DateTime.Now };

            var result =_productService.CreateProductAsync(newProduct).Result;

            Assert.AreEqual(1, result);
        }

        [Test]
        public void ProductAppService_WhenCalled_GetProducts()
        {
            Core.Product.Product newProduct = new Core.Product.Product() { Name = "Name", Price = 1, SystemDate = DateTime.Now };

            _productService.CreateProductAsync(newProduct);

            IEnumerable<Core.Product.Product> productList = _productService.GetProductsAsync().Result;

            Assert.IsTrue(productList.Count() > 0);
        }

        [Test]
        public void ProductAppService_WhenCalled_GetSpecificProduct()
        {
            Core.Product.Product newProduct = new Core.Product.Product() { Name = "Name", Price = 1, SystemDate = DateTime.Now };

            _productService.CreateProductAsync(newProduct);

            Core.Product.Product product = _productService.GetProductByIdAsync(newProduct.Id).Result;

            Assert.AreEqual(newProduct.Id, product.Id);
        }

        [Test]
        public void ProductAppService_WhenCalled_UpdateProduct()
        {
            Core.Product.Product newProduct = new Core.Product.Product() { Name = "Name", Price = 1, SystemDate = DateTime.Now };

            _productService.CreateProductAsync(newProduct);

            newProduct.Name = "New Name";

            Core.Product.Product product = _productService.GetProductByIdAsync(newProduct.Id).Result;

            Assert.AreEqual(newProduct.Name, product.Name);
        }
    }
}
