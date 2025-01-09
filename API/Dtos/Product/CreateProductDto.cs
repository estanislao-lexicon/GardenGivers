using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Product
{
    public class CreateProductDto
    {
        [Required, MaxLength(50)] 
        public string ProductName { get; set; } = string.Empty;
        [Required, MaxLength(200)] 
        public string ProductDescription { get; set; } = string.Empty;
    }
}
