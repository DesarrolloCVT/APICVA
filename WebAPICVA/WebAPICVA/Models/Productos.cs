using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class Productos
    {
        [Key]
        public int Id_Producto { get; set; }
        public string Codigo { get; set; }
        public string Producto { get; set; }
    }
}