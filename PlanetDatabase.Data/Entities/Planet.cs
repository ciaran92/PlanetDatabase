using System.ComponentModel.DataAnnotations.Schema;

namespace PlanetDatabase.Data.Entities
{
    public class Planet
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string PlanetName { get; set; }
        [Column(TypeName = "decimal(5,1)")]
        public decimal DistFromSun { get; set; }
    }
}
