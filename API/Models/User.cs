using System.ComponentModel.DataAnnotations;
using API.Dtos.Request;
using API.Dtos.Offer;

namespace API.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PostNumber { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public List<Offer> Offers { get; set; }
        public List<Request> Requests { get; set; }        
    }
}
