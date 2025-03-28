using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class Subtipos
    {
        [Key]
        public int Id_Subtipos { get; set; }
        public string Identificador { get; set; }
        public string Nombre { get; set; }
    }
}
