using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class ProductosDTO
    {
        [Key]
        public int Id_Producto { get; set; }
        public string Codigo { get; set; }
        public string Producto { get; set; }
    }
}