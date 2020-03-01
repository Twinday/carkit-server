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
using Microsoft.Extensions.Localization;
using Carkit.Services.SearchModels;
using Carkit.Services.DtoModels;

namespace Carkit.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly IDetailService _service;
        private readonly IStringLocalizer<MessagesResource> _localizer;

        public DetailsController(IDetailService service, IStringLocalizer<MessagesResource> localizer)
        {
            _service = service;
            _localizer = localizer;
        }

        /// <summary>
        /// Получение периода обслуживания авто.
        /// </summary>
        /// <param name="searchData">Параметры поиска.</param>
        /// <returns>Время в часах.</returns>
        [HttpGet("TimePeriod")]
        public async Task<ActionResult<double>> GetTimePeriod([FromQuery] TimePeriodSearchData searchData)
        {
            return await _service.GetTimePeriod(searchData.Details, searchData.ModelCarId);
        }

        // GET: api/Details
        [HttpGet]
        public async Task<ActionResult<SearchResult<DetailDto>>> Get([FromQuery] SearchData search)
        {
            return await _service.SearchAsync<DetailDto>(search);
        }

        // GET: api/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailDto>> Get(int id)
        {
            var detail = await _service.GetByIdAsync(id);

            if (detail == null)
            {
                return NotFound();
            }

            return detail;
        }

        // PUT: api/Details/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DetailDto detail)
        {
            if (id != detail.Id)
            {
                return BadRequest();
            }

            if (await _service.Exists(id))
            {
                await _service.UpdateAsync(detail);
            }
            else
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Details
        [HttpPost]
        public async Task<ActionResult<DetailDto>> Post([FromBody] DetailDto detail)
        {
            detail.Id = 0;

            detail.Id = await _service.AddAsync(detail);

            return CreatedAtAction("Get", new { id = detail.Id }, detail);
        }

        // DELETE: api/Details/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetailDto>> Delete(int id)
        {
            var detail = await _service.GetByIdAsync<DetailDto>(id);
            if (detail == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(detail.Id);

            return detail;
        }

    }
}
