using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPICVA.Models
{
    public class IngresosDetalle
    {
        [Key]
        public int Id_Ingreso_Detalle { get; set; } // Clave primaria
        public int Id_Ingreso { get; set; } // Clave foránea que referencia a Ingresos
        public int Folio_FacturaVenta { get; set; }
        public int Monto { get; set; }

        // Propiedad de navegación
        public Ingresos Ingreso { get; set; }
    }
}
