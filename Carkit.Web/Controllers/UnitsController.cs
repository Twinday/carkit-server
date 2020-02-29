using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carkit.Data.Models;
using Carkit.Services.SearchModels;
using Carkit.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carkit.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitService _service;

        public UnitsController(IUnitService service)
        {
            _service = service;
        }

        public async Task<ActionResult<SearchResult<Unit>>> Get([FromQuery] SearchData search)
        {
            return await _service.SearchAsync<Unit>(search);
        }
    }
}