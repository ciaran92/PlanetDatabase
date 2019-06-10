using PlanetDatabase.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanetDatabase.Core.Services.Planets
{
    public interface IPlanetService
    {
        Task<List<Planet>> GetAllPlanets();
        Task<Planet> GetPlanetById(int id);
    }
}
