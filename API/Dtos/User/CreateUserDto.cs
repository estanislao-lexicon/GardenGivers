using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace API.Dtos.User
{
    public class CreateUserDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string PasswordHash { get; set; }
        [Required]
        public required string City { get; set; }
        [Required]
        public required string Address { get; set; }
        [Required]
        public required string PostNumber { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }    
    }
}