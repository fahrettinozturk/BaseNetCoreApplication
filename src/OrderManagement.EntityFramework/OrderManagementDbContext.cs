using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Order;
using OrderManagement.Core.Product;
using OrderManagement.Core.UserManagement;

namespace OrderManagement.EntityFramework
{
    public class OrderManagementDbContext : IdentityDbContext<ApplicationUser>
    {
        public OrderManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
