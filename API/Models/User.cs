using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class User
    {
        public int UserId { get; set; }
        [StringLength(50)]
        public required string FirstName { get; set; }
        [StringLength(50)]
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; }
        public required string PostNumber { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public required List<Offer> Offers { get; set; }
        public required List<Request> Requests { get; set; }
    }
}
