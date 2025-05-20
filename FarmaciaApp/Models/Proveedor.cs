namespace FarmaciaApp.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public required string NombreComercial { get; set; }
        public required string Rfc {  get; set; }
        public required string CodigoPostal { get; set; }
        public required int RegimenFiscal { get; set; }

        public ICollection<ProveedorMedicamento> ProveedorMedicamentos { get; set; }
    }
}
