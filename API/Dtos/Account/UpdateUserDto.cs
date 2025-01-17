namespace API.Dtos.Account
{
    public class UpdateUserDto
    {        
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string City { get; set; }        
        public string Address { get; set; }        
        public string PostNumber { get; set; }
    }
}
