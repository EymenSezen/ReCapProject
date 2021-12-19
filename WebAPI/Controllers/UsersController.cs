using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("getAllByEmail")]
        // [HttpGet]
        public IActionResult Get(string email)
        {



            var result = userService.GetByMail(email);
            
                return Ok(result);
            
           //refactor yapılacak dataresult eklenmemiş ona göre 

        }
    }
}
