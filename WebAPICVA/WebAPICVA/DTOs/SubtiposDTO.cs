using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class SubtiposDTO
    {
        [Key]
        public int Id_Subtipos { get; set; }
        public string Identificador { get; set; }
        public string Nombre { get; set; }
    }
}
