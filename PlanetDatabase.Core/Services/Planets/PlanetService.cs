using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanetDatabase.Data.Context;
using PlanetDatabase.Data.Entities;

namespace PlanetDatabase.Core.Services.Planets
{
    public class PlanetService : IPlanetService
    {
        private readonly PlanetDatabaseContext _context;

        public PlanetService(PlanetDatabaseContext context)
        {
            _context = context;
        }

        // Return a list of all planets
        public async Task<List<Planet>> GetAllPlanets()
        {
            var planets = await _context.Planets.OrderBy(p => p.DistFromSun).ToListAsync();
            return planets;
        }

        public async Task<Planet> GetPlanetById(int id)
        {
            var planet = await _context.Planets.SingleOrDefaultAsync(p => p.Id == id);
            return planet;
        }
    }
}
