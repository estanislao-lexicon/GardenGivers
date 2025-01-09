using System.ComponentModel.DataAnnotations;


namespace API.Dtos.Account
{
    public class LoginDto
    {
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Password { get; set; }        
    }
}
