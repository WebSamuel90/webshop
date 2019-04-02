using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webshop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using webshop.Services;
using webshop.Repositories;

namespace webshop.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductsService productsService;

        public ProductsController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.productsService = new ProductsService(new ProductsRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            return Ok(this.productsService.Get());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            if (this.productsService.Get(id) != null)
            {
                return Ok(this.productsService.Get(id));
            }

            return NotFound();
        }
    }
}
