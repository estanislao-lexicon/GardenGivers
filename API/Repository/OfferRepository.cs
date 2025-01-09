using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using API.Models;
using API.Data;
using API.Helpers;


namespace API.Repository
{
    public class OfferRepository : IOfferRepository
    {
        private readonly ApplicationDbContext _context;

        public OfferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Offer>> GetAllAsync(OfferQueryObject query)
        {
            var offers = _context.Offers
                .Include(t => t.Transactions)
                .Include(r => r.Requests)
                .AsQueryable();
            
            if(query.Quantity.HasValue)
            {
                offers = offers.Where(o => o.Quantity == query.Quantity.Value);
            }
            if(query.IsFree != null)
            {
                offers = offers.Where(o => o.IsFree == query.IsFree.Value);
            }
            if(query.Price.HasValue)
            {
                offers = offers.Where(o => o.Price == query.Price.Value);
            }

            return await offers.ToListAsync();
        }

        public async Task<Offer? > GetByIdAsync(int offerId)
        {
            return await _context.Offers
                .Include(t => t.Transactions)
                .Include(r => r.Requests)
                .FirstOrDefaultAsync(o => o.OfferId == offerId);
        }
        
        public async Task<Offer> CreateAsync(Offer offerModel)
        {
            await _context.Offers.AddAsync(offerModel);
            await _context.SaveChangesAsync();
            return offerModel;
        }

        public async Task<Offer?> DeleteAsync (int offerId)
        {
            var offerModel = await _context.Offers.FirstOrDefaultAsync(o => o.OfferId == offerId);
            
            if(offerModel == null)
                return null;
            
            _context.Offers.Remove(offerModel);
            await _context.SaveChangesAsync();
            return offerModel;
        }

        public Task<bool> OfferExist(int offerId)
        { 
            return _context.Offers.AnyAsync(o => o.OfferId == offerId);
        }
        
        public async Task<Offer?> UpdateAsync (int offerId, Offer offerModel)
        {
            var existingOffer = await _context.Offers.FindAsync(offerId);

            if(existingOffer == null)
                return null;
            
            existingOffer.Quantity = offerModel.Quantity;
            existingOffer.IsFree = offerModel.IsFree;
            existingOffer.Price = offerModel.Price;            
            existingOffer.ExpirationDate = offerModel.ExpirationDate;

            await _context.SaveChangesAsync();
            return existingOffer;
        }
    }
}
