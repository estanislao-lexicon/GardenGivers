using API.Interfaces;
using API.Models;
using API.Data;


namespace API.Repository
{
    public class OfferRepository : IOfferRepository
    {
        private readonly ApplicationDBContext _context;

        public OfferRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool CreateOffer(Offer offer)
        {
            _context.Add(offer);
            return Save();
        }

        public bool DeleteOffer(Offer offer)
        {
            _context.Remove(offer);
            return Save();
        }

        public Offer GetOffer(int offerId)
        {
            return _context.Offers.Where(o => o.OfferId == offerId).FirstOrDefault();
        }

        public ICollection<Offer> GetOffers()
        {
            return _context.Offers.ToList();
        }

        public bool OfferExists(int offerId)
        {
            return _context.Offers.Any(o => o.OfferId == offerId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOffer(Offer offer)
        {
            _context.Update(offer);
            return Save();
        }        
    }
}
