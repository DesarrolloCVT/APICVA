using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class BancoDTO
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
    }
}
