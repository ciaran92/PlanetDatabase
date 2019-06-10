using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlanetDatabase.Core.Services.Planets;
using PlanetDatabase.Data.Models.Planet;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanetDatabase.Controllers
{
    [Route("api/planets")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {
        private readonly IPlanetService _planetService;

        public PlanetsController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlanets()
        {
            // Get All planets
            var planets = await _planetService.GetAllPlanets();

            // Return 204 no content if list is empty
            if(planets.Count() == 0)
            {
                return NoContent();
            }

            // Map to planets List Dto
            var planetsDto = Mapper.Map <IEnumerable<PlanetListDto>>(planets);

            return Ok(planetsDto);
        }
    }
}
