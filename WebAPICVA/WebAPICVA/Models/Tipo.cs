using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class Tipo
    {
        [Key]
        public int Id_Tipo { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo_Dato { get; set; }
        public int Cuenta { get; set; }
    }
}
