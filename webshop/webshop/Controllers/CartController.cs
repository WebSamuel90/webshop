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
    public class CartController : Controller
    {
        private readonly CartService cartService;

        public CartController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartService = new CartService(new CartRepository(connectionString));
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(List<Cart>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string guid)
        {
            var result = this.cartService.Get(guid);
            return Ok(result);
        }
    }
}
