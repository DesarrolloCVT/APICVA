using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.Models
{
    public class Producto
    {
        [Key]
        public int codigo { get; set; }
        public string producto { get; set; }
    }
}