using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class FacturaCompra
    {
        [Key]
        public int Folio { get; set; }
        public string Proveedor { get; set; }
        public DateTime Fecha { get; set; }
        public string Moneda { get; set; }
    }
}
