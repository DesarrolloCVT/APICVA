using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class Moneda
    {
        [Key]
        public int Id_Monedas { get; set; }
        public string Nombre { get; set; }
    }
}
