using FarmaciaApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaApp.Data
{
    public class FarmaciaDbContext : IdentityDbContext<FarmaciaUser>
    {
        public FarmaciaDbContext(DbContextOptions<FarmaciaDbContext> options) : base(options)
        {
        }
        public DbSet<Medicamento> Medicamentos { get; set; }

        

    }
}