using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebAPICVA.Models;

namespace WebAPICVA.DTOs
{
    public class FacturaCompraDetalleDTO
    {
        [Key]
        public int Id_Factura_Compra_Detalle { get; set; }
        public int Id_Factura_Compra { get; set; }
        public int Folio { get; set; }
        public string Codigo_Producto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
    }
}
