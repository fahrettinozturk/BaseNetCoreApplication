using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private OrderManagementDbContext dbContext;

        public TestController(OrderManagementDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return dbContext.Users.Select(u => u.UserName).ToArray();
        }
    }
}
