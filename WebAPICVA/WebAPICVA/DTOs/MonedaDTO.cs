using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class MonedaDTO
    {
        [Key]
        public int Id_Monedas { get; set; }
        public string Nombre { get; set; }
    }
}
