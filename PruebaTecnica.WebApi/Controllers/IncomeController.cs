using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models.Dtos.Generic;
using PruebaTecnica.Models.Dtos;
using PruebaTecnica.Services.Interfaces;
using PruebaTecnica.Models.PayLoad;

namespace PruebaTecnica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        /// <summary>
        /// Obtiene los carros disponibles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseServiceDto<List<CountryDto>>>> GetCountries([FromQuery]CarAvailableFilterLoad carAvailableFilterLoad)
        {
            return Ok(await _incomeService.GetCarAvailable(carAvailableFilterLoad));
        }
    }
}
