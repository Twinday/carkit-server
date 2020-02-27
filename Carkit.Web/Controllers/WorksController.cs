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
using Carkit.Services.DtoModels.Work;

namespace Carkit.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksController : ControllerBase
    {
        private readonly IWorkService _service;
        private readonly IStringLocalizer<MessagesResource> _localizer;

        public WorksController(IWorkService service, IStringLocalizer<MessagesResource> localizer)
        {
            _service = service;
            _localizer = localizer;
        }

        // GET: api/Works/details
        /// <summary>
        /// Возвраает работы с деталями под нужное авто для заказа.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("details")]
        public async Task<ActionResult<WorkSearchResult>> Get([FromQuery] WorkSearchData search)
        {
            var result = await _service.SearchAsync<WorkListView>(search);

            return await _service.GetLinkedDetailsForModelCar(result, search);
        }

        // GET: api/Works
        /// <summary>
        /// Поиск видов работ (для реестра работ).
        /// </summary>
        /// <param name="search">Параметры поиска.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<SearchResult<WorkDto>>> Get([FromQuery] SearchData search)
        {
            return await _service.SearchAsync<WorkDto>(search);
        }

        // GET: api/Works/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkDto>> Get(int id)
        {
            var work = await _service.GetByIdAsync(id);

            if (work == null)
            {
                return NotFound();
            }

            return work;
        }

        // PUT: api/Works/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] WorkDto work)
        {
            if (id != work.Id)
            {
                return BadRequest();
            }

            if (await _service.Exists(id))
            {
                await _service.UpdateAsync(work);
            }
            else
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Works
        [HttpPost]
        public async Task<ActionResult<WorkDto>> Post(WorkDto work)
        {
            work.Id = 0;

            work.Id = await _service.AddAsync(work);

            return CreatedAtAction("Get", new { id = work.Id }, work);
        }

        // DELETE: api/Works/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkDto>> Delete(int id)
        {
            var work = await _service.GetByIdAsync<WorkDto>(id);
            if (work == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(work.Id);

            return work;
        }

    }
}
