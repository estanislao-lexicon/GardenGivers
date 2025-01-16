namespace API.Dtos.Account
{
    public class UserLoggedDto
    {
        public required string UserId { get; set; }        
        public required string? Username { get; set; }
        public required string? Email { get; set; }        
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; }
        public required string PostNumber { get; set; }       
    }
}
