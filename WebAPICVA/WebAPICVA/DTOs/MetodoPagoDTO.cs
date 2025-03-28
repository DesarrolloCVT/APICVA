using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class MetodoPagoDTO
    {
        [Key]
        public int Id_Metodo_Pago { get; set; }
        public string Nombre { get; set; }
    }
}
