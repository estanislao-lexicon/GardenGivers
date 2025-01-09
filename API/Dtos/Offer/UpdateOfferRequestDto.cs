using System.ComponentModel.DataAnnotations;


namespace API.Dtos.Offer
{
    public class UpdateOfferRequestDto
    {
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public bool IsFree { get; set; }
        public decimal Price { get; set; } 
        public DateTime ExpirationDate { get; set; }    
    }
}
