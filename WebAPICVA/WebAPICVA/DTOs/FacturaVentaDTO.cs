using System.ComponentModel.DataAnnotations;
using WebAPICVA.Models;

namespace WebAPICVA.DTOs
{
    public class FacturaVentaDTO
    {
        [Key]
        public int Id_Factura_Venta { get; set; }
        public int Folio { get; set; }
        public string Cliente { get; set; }
        public string Direccion_Despacho { get; set; }
        public string Moneda { get; set; }
        public DateTime Fecha { get; set; }

        // Relación con TransaccionDetalle (Uno a muchos)
        //public ICollection<FacturaVentaDetalle> FacturaVentasDetalles { get; set; }
    }
}
