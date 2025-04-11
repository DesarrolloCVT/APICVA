using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class FacturaVentaDetalle
    {
        [Key]
        public int Id_Factura_Venta_Detalle { get; set; }
        public int Id_Factura_Venta { get; set; }
        public int Folio {  get; set; }
        public string Codigo_Producto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }

        // Propiedad de navegación
        public FacturaVenta FacturaVentas { get; set; }
    }
}
