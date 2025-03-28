using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class Egresos
    {
        [Key]
        public int Id_Egreso { get; set; }
        public int Folio { get; set; }
        public string Tipo_Transaccion { get; set; }
        public string Subtipo_Transaccion { get; set; }
        public string Moneda { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string Metodo_Pago { get; set; }
        public string Banco { get; set; }
        public string Cuenta { get; set; }
    }
}
