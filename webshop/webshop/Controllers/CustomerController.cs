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
    public class CustomerController
    {
        [Route("api/[controller]")]
        public class CartController : Controller
        {
            private readonly CustomerService customerService;

            public CartController(IConfiguration configuration)
            {
                var connectionString = configuration.GetConnectionString("ConnectionString");
                this.customerService = new CustomerService(new CustomerRepository(connectionString));
            }

            [HttpPost]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public IActionResult Post([FromBody]Customer customer)
            {
                var result = this.customerService.Add(customer);

                if (!result)
                {
                    return BadRequest();
                }

                return Ok();
            }

            [HttpGet]
            [ProducesResponseType(typeof(List<Customer>), StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public IActionResult Get()
            {
                return Ok(this.customerService.Get());
            }

            [HttpGet("{guid}")]
            [ProducesResponseType(typeof(List<Customer>), StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public IActionResult Get(string guid)
            {
                var result = this.customerService.Get(guid);
                return Ok(result);
            }
        }
    }
}
