using API.Dtos.Offer;
using API.Dtos.Request;

namespace API.Dtos.User
{
    public class UserDto
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; }
        public required string PostNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public required List<OfferDto> Offers { get; set; }
        public required List<RequestDto> Requests { get; set; }
    }
}
