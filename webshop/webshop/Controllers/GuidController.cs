using System;
using Microsoft.AspNetCore.Mvc;

namespace webshop.Controllers
{
    [Route("api/[controller]")]
    public class MyGuidController : Controller
    {
        [HttpGet]
        public Guid Get()
        {
            Guid guid;
            guid = Guid.NewGuid();
            return guid;
        }
    }
}
