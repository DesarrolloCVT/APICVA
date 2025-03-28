using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class TipoDTO
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo_Dato { get; set; }
        public int Cuenta { get; set; }
    }
}
