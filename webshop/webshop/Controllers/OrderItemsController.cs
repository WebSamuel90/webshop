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
    public class OrderItemsController
    {
        [Route("api/[controller]")]
        public class CartController : Controller
        {
            private readonly OrderItemsService orderItemsService;

            public CartController(IConfiguration configuration)
            {
                var connectionString = configuration.GetConnectionString("ConnectionString");
                this.orderItemsService = new OrderItemsService(new OrderItemsRepository(connectionString));
            }

            [HttpGet("{guid}")]
            [ProducesResponseType(typeof(List<OrderItems>), StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public IActionResult Get(string guid)
            {
                var result = this.orderItemsService.Get(guid);
                return Ok(result);
            }
        }
    }
}
