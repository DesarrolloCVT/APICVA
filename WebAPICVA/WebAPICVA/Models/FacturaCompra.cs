using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class FacturaCompra
    {
        [Key]
        public int Id_Factura_Compra { get; set; }
        public int Folio { get; set; }
        public string Proveedor { get; set; }
        public DateTime Fecha { get; set; }
        public string Moneda { get; set; }
        private long Total {  get; set; }

        // Relación con TransaccionDetalle (Uno a muchos)
        public ICollection<FacturaCompraDetalle> FacturaComprasDetalles { get; set; }
    }
}
