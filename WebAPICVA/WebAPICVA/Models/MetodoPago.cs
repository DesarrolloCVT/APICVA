using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class MetodoPago
    {
        [Key]
        public int Id_Metodo_Pago { get; set; }
        public string Nombre { get; set; }
    }
}
