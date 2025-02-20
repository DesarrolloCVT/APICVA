using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class BancoDetalle
    {
        [Key]
        public int Codigo_Banco { get; set; }
        public int Numero { get; set; }
    }
}
