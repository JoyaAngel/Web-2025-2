using ProyectoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoWebApi.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
    public DbSet<Alumno> Alumnos { get; set; }
}
