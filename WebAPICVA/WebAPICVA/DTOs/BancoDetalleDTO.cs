using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class BancoDetalleDTO
    {
        [Key]
        public int Codigo_Banco { get; set; }
        public int Numero { get; set; }
        public int Saldo { get; set; }
    }
}
