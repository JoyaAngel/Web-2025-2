using System.ComponentModel.DataAnnotations;

namespace FarmaciaApp.Models
{
    public class Medicamento
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public string? RutaImagen { get; set; }

    }
}
