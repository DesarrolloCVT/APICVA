using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class Cuentas
    {
        [Key]
        public int Id_Cuenta { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
    }
}
