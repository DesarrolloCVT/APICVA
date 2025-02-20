using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class FacturaVentaDetalle
    {
        [Key]
        public int Folio {  get; set; }
        public string Codigo_Producto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
    }
}
