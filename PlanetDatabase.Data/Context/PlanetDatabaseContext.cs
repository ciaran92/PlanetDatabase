using Microsoft.EntityFrameworkCore;
using PlanetDatabase.Data.Entities;

namespace PlanetDatabase.Data.Context
{
    public class PlanetDatabaseContext : DbContext
    {
        public PlanetDatabaseContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Planet> Planets { get; set; }
    }
}
