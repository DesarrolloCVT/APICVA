using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class IngresosDetalle
    {
        [Key]
        public int Folio_FacturaVenta { get; set; }
        public int Monto { get; set; }
    }
}
