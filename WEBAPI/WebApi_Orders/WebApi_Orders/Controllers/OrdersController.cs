using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Orders.Models;

namespace WebApi_Orders.Controllers
{
    public class OrdersController : ApiController
    {
        private OrdersDBEntities db = new OrdersDBEntities();

        [HttpGet]
        [Route("api/orders/byemployee/5")]
        public IHttpActionResult GetOrdersByEmployee()
        {
            var orders = db.Orders.Where(o => o.EmployeeID == 5).ToList();
            return Ok(orders);
        }
    }
}
