using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class Tipo
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo_Dato { get; set; }
        public string Cuenta { get; set; }
        public int Pago_Factura { get; set; }
        public int Gasto_Comercializacion { get; set; }
        public int Comisiones { get; set; }
        public int Gasto_Financiero { get; set; }
        public int Anticipo { get; set; }
    }
}
