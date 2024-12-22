namespace API.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string City { get; set; }        
        public string Address { get; set; }        
        public string PostNumber { get; set; }
        public DateTime DateCreated { get; set; }        
    }
}
