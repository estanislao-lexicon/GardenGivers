using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using API.Models;
using API.Data;
using API.Dtos.Offer;
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
                .AsQueryable();
            
            if(query.Quantity  != null)
            {
                offers = offers.Where(o => o.Quantity == query.Quantity);
            }
            if(query.IsFree != null)
            {
                offers = offers.Where(o => o.IsFree == query.IsFree);
            }
            if(query.Price != null)
            {
                offers = offers.Where(o => o.Price == query.Price);
            }            

            return await offers.ToListAsync();
        }
        public async Task<Offer? > GetByIdAsync(int offerId)
        {
            return await _context.Offers
                .Include(t => t.Transactions)
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
