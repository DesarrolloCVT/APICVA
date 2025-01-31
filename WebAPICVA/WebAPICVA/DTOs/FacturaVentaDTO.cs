using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class FacturaVentaDTO
    {
        [Key]
        public int Folio { get; set; }
        public string Cliente { get; set; }
        public string Dir_Despacho { get; set; }
        public string Moneda { get; set; }
        public string Fecha { get; set; }
        public string Total { get; set; }
    }
}
