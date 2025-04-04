using System.ComponentModel.DataAnnotations;
using WebAPICVA.Models;

namespace WebAPICVA.DTOs
{
    public class TransaccionDetalleDTO
    {
        [Key]
        public int Id_Transaccion_Detalle { get; set; } // Clave primaria
        public int Id_Transaccion { get; set; } // Clave foránea que referencia a Ingresos
        public int Folio_Factura { get; set; }
        public string Tipo_Factura { get; set; }
        public int Monto { get; set; }

        // Propiedad de navegación
        //public Transacciones Transaccion { get; set; }
    }
}
