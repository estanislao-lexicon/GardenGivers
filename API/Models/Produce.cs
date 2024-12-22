namespace API.Models
{
    public class Produce
    {
        public int ProduceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
