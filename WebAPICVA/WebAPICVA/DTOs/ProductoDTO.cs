using System.ComponentModel.DataAnnotations;

namespace WebAPICVA.DTOs
{
    public class ProductoDTO
    {
        [Key]
        public int codigo { get; set; }
        public string producto { get; set; }
    }
}