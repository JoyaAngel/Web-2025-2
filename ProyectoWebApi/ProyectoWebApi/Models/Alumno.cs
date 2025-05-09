namespace ProyectoWebApi.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? CorreoElectronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
