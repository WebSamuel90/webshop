using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using webshop.Models;
using webshop.Repositories;
using webshop.Services;

namespace webshop.Controllers
{
    [Route("api/[controller]")]
    public class CheckoutController : Controller
    {
        private readonly CheckoutService checkoutService;

        public CheckoutController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.checkoutService = new CheckoutService(new CustomerRepository(connectionString), new OrderItemsRepository(connectionString));
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(List<Order>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string guid)
        {
            var result = this.checkoutService.Get(guid);
            return Ok(result);
        }
    }
}
