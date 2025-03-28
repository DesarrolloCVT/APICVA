using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace WebAPICVA.Models
{
    public class FacturaCompraDetalle
    {
        [Key]
        public int Id_Factura_Compra_Detalle { get; set; }
        public int Folio {  get; set; }
        public string Codigo_Producto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
    }
}
