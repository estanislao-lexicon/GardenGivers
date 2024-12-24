using API.Models;

namespace API.Interfaces
{
    public interface IOfferRepository
    {
        ICollection<Offer> GetOffers();
        Offer GetOffer(int offerId);        
        bool OfferExists(int offerId);
        bool CreateOffer(Offer offer);
        bool UpdateOffer(Offer offer);
        bool DeleteOffer(Offer offer);
        bool Save();        
    }
}
