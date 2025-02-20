using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class IngresosDTO
    {
        [Key]
        public int Folio { get; set; }
        public string Tipo { get; set; }
        public string Moneda { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string Metodo_Pago { get; set; }
        public string Banco { get; set; }
        public string Cuenta { get; set; }
    }
}
