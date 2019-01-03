using Microsoft.EntityFrameworkCore;
using OrderManagement.EntityFramework;
using System;

namespace OrderManagement.Test.Shared
{
    public class TestBase
    {
        protected readonly OrderManagementDbContext OrderManagementInMemoryDbContext;

        public TestBase()
        {
            OrderManagementInMemoryDbContext = GetInitializeDbContext();
        }

        public static OrderManagementDbContext GetInitializeDbContext()
        {
            var inMemoryContext = GetEmptyDBContext();

            inMemoryContext.SaveChangesAsync();
            return inMemoryContext;
        }

        private static OrderManagementDbContext GetEmptyDBContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderManagementDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            optionsBuilder.EnableSensitiveDataLogging();
            var inMemoryContext = new OrderManagementDbContext(optionsBuilder.Options);
            return inMemoryContext;
        }
    }
}
