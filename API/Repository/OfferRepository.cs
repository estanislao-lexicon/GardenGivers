using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFramworkCore;
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

        public OfferRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Offer>> GetAllAsync(QueryObject query)
        {
            return await _context.Offers.ToListAsync();
        }
        public async Task<Offer? > GetByIdAsync(int offerId)
        {
            return await _context.Offers.FindAsync(offerId);
        }
        public async Task<Offer> CreateAsync(Offer offerModel)
        {
            await _context.Offers.AddAsync(offerModel);
            await _context.SaveChangesAsync();
            return offerModel;
        }

        public async Task<Offer?> DeleteAsync (int offerId)
        {
            var offerModel = await _context.Offers.FirstOrDefaultAsync(o => o.OfferId = offerId);
            
            if(offerModel == null)
            {
                return null;
            }

            _context.Offers.Remove(offerModel);
            await _context.SaveChangesAsync();
            return offerModel;
        }

        public Task<bool> OfferExists(int offerId)
        { 
            return _context.Offers.AnyAsync(o => o.OfferId == offerId);
        }
        public async Task<Offer?> UpdateAsync (int offerId, UpdateOfferRequestDto offerDto)
        {
            var existingOffer = await _context.Offers.FirstOrDefaultAsync(o => o.OfferId == offerId);

            if(existingOffer == null)
            {
                return null;
            }

            existingOffer.Quantity = offerDto.Quantity;
            existingOffer.IsFree = offerDto.IsFree;
            existingOffer.Price = offerDto.Price;
            existingOffer.DateCreated = offerDto.DateCreated;
            existingOffer.ExpirationDate = offerDto.ExpirationDate;

            await _context.SaveChangesAsync();
            return existingOffer;
        }
    }
}
