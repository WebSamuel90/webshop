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
    public class CartItemController : Controller
    {
        private readonly CartItemsService cartItemsService;

        public CartItemController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartItemsService = new CartItemsService(new CartItemsRepository(connectionString));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]CartItems cartItem)
        {
            var result = this.cartItemsService.Add(cartItem);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CartItems>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            return Ok(this.cartItemsService.Get());
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(List<CartItems>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string guid)
        {
            var result = this.cartItemsService.Get(guid);
            return Ok(result);
        }
    }
}
