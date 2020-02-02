using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carkit.Data;
using Carkit.Data.Models;
using Carkit.Services.Services;
using Carkit.Services.SearchModels;
using Carkit.Services.DtoModels;

namespace Carkit.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecomendedWorksController : ControllerBase
    {
        private readonly IRecomendedWorkService _service;

        public RecomendedWorksController(IRecomendedWorkService service)
        {
            _service = service;
        }

        // GET: api/RecomendedWorks
        [HttpGet]
        public async Task<ActionResult<SearchResult<WorkForCarDto>>> Get([FromQuery] SearchData search)
        {
            return await _service.SearchAsync<WorkForCarDto>(search);
        }

        // GET: api/RecomendedWorks/5
        /*[HttpGet("{id}")]
        public async Task<ActionResult<WorkForCar>> GetWorkForCar(int id)
        {
            var workForCar = await _context.WorkForCars.FindAsync(id);

            if (workForCar == null)
            {
                return NotFound();
            }

            return workForCar;
        }*/

        // PUT: api/RecomendedWorks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkForCar(int id, [FromBody] WorkForCarDto workForCar)
        {
            if (id != workForCar.Id)
            {
                return BadRequest();
            }

            if (await _service.Exists(id))
            {
                await _service.UpdateAsync(workForCar);
            }
            else
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/RecomendedWorks
        [HttpPost]
        public async Task<ActionResult<WorkForCarDto>> Post([FromBody] WorkForCarDto workForCar)
        {
            workForCar.Id = 0;

            workForCar.Id = await _service.AddAsync(workForCar);

            return CreatedAtAction("Get", new { id = workForCar.Id }, workForCar);
        }

        // DELETE: api/RecomendedWorks/5
        /*[HttpDelete("{id}")]
        public async Task<ActionResult<WorkForCar>> DeleteWorkForCar(int id)
        {
            var workForCar = await _context.WorkForCars.FindAsync(id);
            if (workForCar == null)
            {
                return NotFound();
            }

            _context.WorkForCars.Remove(workForCar);
            await _context.SaveChangesAsync();

            return workForCar;
        }*/

    }
}
