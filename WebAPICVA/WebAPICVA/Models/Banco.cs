using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class Banco
    {
        [Key]
        public int Id_Banco { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        // Relación con TransaccionDetalle (Uno a muchos)
        public ICollection<BancoDetalle> BancoDetalles { get; set; }
    }
}
