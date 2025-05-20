using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaApp.Models
{
    public class ProveedorMedicamento
    {
        [ForeignKey ("Medicamento")]
        public required int MedicamentoId { get; set; }
        public Medicamento? Medicamento { get; set; }
        [ForeignKey ("Proveedor")]
        public required int ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }

        public required int piezas { get; set; }
        public required DateTime FechaRegistro { get; set; }
        public required DateTime FechaActualizacion { get; set; }
    }
}
