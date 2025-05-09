using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions <ApiDbContext> options) : base(options) { }

    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Doctor> Doctores { get; set; }
}
