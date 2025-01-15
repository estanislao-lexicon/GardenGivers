using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class User : IdentityUser
    {     
        [StringLength(50)]
        public required string FirstName { get; set; }
        [StringLength(50)]
        public required string LastName { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; }
        public required string PostNumber { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public List<Offer> Offers { get; set; } = new List<Offer>();
        public List<Request> Requests { get; set; } = new List<Request>();
    }
}
