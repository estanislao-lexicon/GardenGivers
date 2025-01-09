using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Product
{
    public class UpdateProductRequestDto
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
    }
}
