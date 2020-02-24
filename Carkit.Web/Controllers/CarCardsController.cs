﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carkit.Services.DtoModels;
using Carkit.Services.SearchModels;
using Carkit.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carkit.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarCardsController : ControllerBase
    {
        private readonly ICarCardService _service;
        public CarCardsController(ICarCardService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<SearchResult<CarCardView>>> Get([FromQuery] SearchData search)
        {
            return await _service.SearchAsync<CarCardView>(search);
        }
    }
}