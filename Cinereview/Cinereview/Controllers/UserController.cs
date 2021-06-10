using Cinereview.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinereview.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        public UserService Service { get; set; }

        public UserController(UserService Service)
        {
            this.Service = Service;
        }

        [HttpGet]
        [Route("hello-world")]
        public String GetHelloWorld()
        {
            return Service.GetHelloWorld();
        }
    }
}
