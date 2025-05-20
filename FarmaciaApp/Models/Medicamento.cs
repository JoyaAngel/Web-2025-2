using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaApp.Models
{
    public class Medicamento
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        [Precision(10, 2)]
        public Decimal Precio { get; set; }
        public string? RutaImagen { get; set; }

        public ICollection<ProveedorMedicamento> ProveedorMedicamentos { get; set; }
    }
}
