using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class FacturaVentaDetalleDTO
    {
        [Key]
        public int Folio { get; set; }
        public int Codigo_Producto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
    }
}
