using Microsoft.EntityFrameworkCore;

namespace FarmaciaApp.Data
{
    public class FarmaciaDbContext : DbContext
    {
        public FarmaciaDbContext(DbContextOptions<FarmaciaDbContext> options) : base(options) 
        { 
        }

        public DbSet<FarmaciaApp.Models.Medicamento> Medicamentos { get; set; }
    }
}
