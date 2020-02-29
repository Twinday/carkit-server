using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carkit.Data;
using Carkit.Data.Models;
using Carkit.Services.SearchModels;
using Carkit.Services.DtoModels;
using Carkit.Services.Services;
using Microsoft.Extensions.Localization;

namespace Carkit.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairShopsController : ControllerBase
    {
        private readonly IRepairShopService _service;
        private readonly IStringLocalizer<MessagesResource> _localizer;

        public RepairShopsController(IRepairShopService service, IStringLocalizer<MessagesResource> localizer)
        {
            _service = service;
            _localizer = localizer;
        }

        [HttpGet("Time/{id}")]
        public async Task<ActionResult<List<string>>> GetFreeTime(int id)
        {
            return await _service.GetFreeTime(id);
        }

        // GET: api/RepairShops
        /// <summary>
        /// Поиск автомастерских.
        /// </summary>
        /// <param name="search">Параметры поиска.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<SearchResult<RepairShopDto>>> Get([FromQuery] SearchData search)
        {
            return await _service.SearchAsync<RepairShopDto>(search);
        }

        // GET: api/RepairShops/5
        /// <summary>
        /// Возвращает автомастерскую.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairShopDto>> Get(int id)
        {
            var repairShop = await _service.GetByIdAsync(id);

            if (repairShop == null)
            {
                return NotFound();
            }

            return repairShop;
        }

        // PUT: api/RepairShops/5
        /// <summary>
        /// Обновляет данные автомастерской.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repairShop"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RepairShopDto repairShop)
        {
            if (id != repairShop.Id)
            {
                return BadRequest();
            }

            if (await _service.Exists(id))
            {
                await _service.UpdateAsync(repairShop);
            }
            else
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/RepairShops
        [HttpPost]
        public async Task<ActionResult<RepairShopDto>> Post([FromBody] RepairShopDto repairShop)
        {
            repairShop.Id = 0;
            if (!await _service.CanAdd(repairShop))
            {
                ModelState.AddModelError(nameof(RepairShopDto), _localizer[Messages.ObjectWithNameExists]);
                return BadRequest(ModelState);
            }

            repairShop.Id = await _service.AddAsync(repairShop);

            return CreatedAtAction("Get", new { id = repairShop.Id }, repairShop);
        }

        // DELETE: api/RepairShops/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepairShopDto>> Delete(int id)
        {
            var repairShop = await _service.GetByIdAsync<RepairShopDto>(id);
            if (repairShop == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(repairShop.Id);

            return repairShop;
        }

    }
}
