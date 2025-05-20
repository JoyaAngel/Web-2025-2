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
        public DbSet<Proveedor> Proovedores { get; set; }
        public DbSet<ProveedorMedicamento> ProveedorMedicamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProveedorMedicamento>()
            .HasKey(pm => new { pm.ProveedorId, pm.MedicamentoId }); 

            modelBuilder.Entity<ProveedorMedicamento>()
                .HasOne(pm => pm.Proveedor)
                .WithMany(p => p.ProveedorMedicamentos)
                .HasForeignKey(pm => pm.ProveedorId);

            modelBuilder.Entity<ProveedorMedicamento>()
                .HasOne(pm => pm.Medicamento)
                .WithMany(m => m.ProveedorMedicamentos)
                .HasForeignKey(pm => pm.MedicamentoId);
        }



    }
}
