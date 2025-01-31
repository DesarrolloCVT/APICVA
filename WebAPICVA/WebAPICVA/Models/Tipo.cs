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
    }
}
