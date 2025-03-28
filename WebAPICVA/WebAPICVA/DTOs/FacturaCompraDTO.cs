using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class FacturaCompraDTO
    {
        [Key]
        public int Id_Factura_Compra { get; set; }
        public int Folio { get; set; }
        public string Proveedor { get; set; }
        public DateTime Fecha { get; set; }
        public string Moneda { get; set; }
    }
}
