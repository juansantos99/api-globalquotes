using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stocks_api.Models;
using stocks_api.Services;
using AutoMapper;


namespace stocks_api.Controllers
{
    [Route("api/global-quotes")]
    [ApiController]
    public class GlobalQuotesController : ControllerBase
    {
        private IGlobalQuotesService _service;
        private readonly IMapper _mapper;

        public GlobalQuotesController(IGlobalQuotesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task <List<GlobalQuotes>> GetGlobalQuotes(string symbol)
        {
            return await _service.GetGlobalQuotes(symbol);
            //return Ok(_mapper.Map<List<GlobalQuotes>>(global));
        }

    }
}