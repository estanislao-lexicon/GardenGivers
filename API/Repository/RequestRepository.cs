using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using API.Models;
using API.Data;
using API.Dtos.Request;
using API.Helpers;

namespace API.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Request>> GetAllAsync(RequestQueryObject query)
        {
            var requests = _context.Requests
                .Include(t => t.Transactions)
                .AsQueryable();
            
            if(query.Quantity != null)
            {
                requests = requests.Where(r => r.Quantity == query.Quantity);
            }

            return await requests.ToListAsync();
        }
        public async Task<Request?> GetByIdAsync(int requestId)
        {
            return await _context.Requests
                .Include(t => t.Transactions)
                .FirstOrDefaultAsync(i => i.RequestId == requestId);
        }
        public async Task<Request> CreateAsync(Request requestModel)
        {
            await _context.Requests.AddAsync(requestModel);
            await _context.SaveChangesAsync();
            return requestModel;
        }

        public async Task<Request?> DeleteAsync (int requestId)
        {
            var requestModel = await _context.Requests.FirstOrDefaultAsync(r => r.RequestId == requestId);
            
            if(requestModel == null)
            {
                return null;
            }

            _context.Requests.Remove(requestModel);
            await _context.SaveChangesAsync();
            return requestModel;
        }

        public Task<bool> RequestExist(int requestId)
        { 
            return _context.Requests.AnyAsync(r => r.RequestId == requestId);
        }
        public async Task<Request?> UpdateAsync (int requestId, Request requestModel)
        {
            var existingRequest = await _context.Requests.FindAsync(requestId);

            if(existingRequest == null)
                return null;
            
            existingRequest.Quantity = requestModel.Quantity;            

            await _context.SaveChangesAsync();
            return existingRequest;
        }
    }
}
