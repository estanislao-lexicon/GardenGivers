using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Helpers;
using API.Dtos.Offer;

namespace API.Interfaces
{
    public interface IOfferRepository
    {
        Task<List<Offer>> GetAllAsync();
        Task<Offer?> GetByIdAsync(int offerId);
        Task<Offer> CreateAsync(Offer offerModel);
        Task<Offer?> UpdateAsync(int offerId, Offer offerModel);
        Task<Offer?> DeleteAsync (int offerId);
        Task<bool> OfferExists(int offerId);
    }
}
