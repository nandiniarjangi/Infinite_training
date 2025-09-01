using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Orders.Models;

namespace WebApi_Orders.Controllers
{
    public class CustomersController : ApiController
    {
        private OrdersDBEntities db = new OrdersDBEntities();

        [HttpGet]
        [Route("api/customers/bycountry/{country}")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var customers = db.GetCustomersByCountry(country).ToList();
            return Ok(customers);
        }
    }
}
