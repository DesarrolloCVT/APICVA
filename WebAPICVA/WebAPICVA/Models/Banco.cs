using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class Banco
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
    }
}
