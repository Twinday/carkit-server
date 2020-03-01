using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carkit.Services.DtoModels;
using Carkit.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carkit.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _service;
        public CarsController(ICarService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<CarDto>> Post([FromBody] CarDto car)
        {
            car.Id = 0;

            car.Id = await _service.AddAsync(car);

            //return CreatedAtAction("Get", new { id = user.Id }, user);
            return car;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CarDto car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            if (await _service.Exists(id))
            {
                await _service.UpdateAsync(car);
            }
            else
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}