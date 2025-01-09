using API.Models;
using API.Helpers;

namespace API.Interfaces
{
    public interface IOfferRepository
    {
        Task<List<Offer>> GetAllAsync(OfferQueryObject query);
        Task<Offer?> GetByIdAsync(int offerId);
        Task<Offer> CreateAsync(Offer offerModel);
        Task<Offer?> UpdateAsync(int offerId, Offer offerModel);
        Task<Offer?> DeleteAsync (int offerId);
        Task<bool> OfferExist(int offerId);
    }
}
