using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carkit.Services.DtoModels.Auth;
using Carkit.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carkit.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserDto user)
        {
            user.Id = 0;

            user.Id = await _service.AddAsync(user);

            //return CreatedAtAction("Get", new { id = user.Id }, user);
            return user;
        }
    }
}