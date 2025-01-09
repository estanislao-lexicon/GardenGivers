using System.ComponentModel.DataAnnotations;

namespace API.Dtos.User
{
    public class CreateUserDto
    {
        [Required, MaxLength(50)] 
        public required string FirstName { get; set; }
        [Required, MaxLength(50)] 
        public required string LastName { get; set; }
        [Required, EmailAddress] 
        public required string Email { get; set; }
        [Required, MinLength(8)] 
        public required string PasswordHash { get; set; }
        [Required, MaxLength(100)] 
        public required string City { get; set; }
        [Required, MaxLength(200)] 
        public required string Address { get; set; }
        [Required, RegularExpression(@"^\d{5}", ErrorMessage = "Post number must be 5 digits long")] 
        public required string PostNumber { get; set; }
    }
}
