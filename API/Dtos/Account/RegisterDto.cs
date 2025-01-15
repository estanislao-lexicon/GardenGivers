using System.ComponentModel.DataAnnotations;
using API.Dtos.Offer;
using API.Dtos.Request;

namespace API.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; }
        public required string PostNumber { get; set; }       
    }
}
