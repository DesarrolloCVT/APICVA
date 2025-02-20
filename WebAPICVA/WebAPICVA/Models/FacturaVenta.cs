using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class FacturaVenta
    {
        [Key]
        public int Folio { get; set; }
        public string Cliente { get; set; }
        public string Direccion_Despacho { get; set; }
        public string Moneda { get; set; }
        public DateTime Fecha { get; set; }
    }
}
