using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Request
{
    public class CreateRequestDto
    {
        [Required]
        public decimal Quantity { get; set; }        
    }
}
