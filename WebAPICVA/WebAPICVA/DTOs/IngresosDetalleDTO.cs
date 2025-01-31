using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class IngresosDetalleDTO
    {
        [Key]
        public int Folio_FacturaVenta { get; set; }
        public int Monto { get; set; }
    }
}
