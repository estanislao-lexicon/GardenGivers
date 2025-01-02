using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFramworkCore;
using API.Interfaces;
using API.Models;
using API.Data;
using API.Dtos.Request;
using API.Helpers;

namespace API.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDBContext _context;

        public RequestRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Request>> GetAllAsync(QueryObject query)
        {
            return await _context.Requests.ToListAsync();
        }
        public async Task<Request?> GetByIdAsync(int requestId)
        {
            return await _context.Requests.Include(r => r.requestId).FirstOrDefaultAsync(i => i.RequestId == requestId);
        }
        public async Task<Request> CreateAsync(Request requestModel)
        {
            await _context.Requests.AddAsync(requestModel);
            await _context.SaveChangesAsync();
            return requestModel;
        }

        public async Task<Request?> DeleteAsync (int requestId)
        {
            var requestModel = await _context.Requests.FirstOrDefaultAsync(r => r.RequestId = requestId);
            
            if(requestModel == null)
            {
                return null;
            }

            _context.Requests.Remove(requestModel);
            await _context.SaveChangesAsync();
            return requestModel;
        }

        public Task<bool> RequestExists(int requestId)
        { 
            return _context.Requests.AnyAsync(r => r.RequestId == requestId);
        }
        public async Task<Request?> UpdateAsync (int requestId, UpdateRequestRequestDto requestDto)
        {
            var existingRequest = await _context.Requests.FirstOrDefaultAsync(r => r.RequestId == requestId);

            if(existingRequest == null)
            {
                return null;
            }

            existingRequest.Quantity = requestDto.Quantity;
            existingRequest.DateCreated = requestDto.DateCreated;

            await _context.SaveChangesAsync();
            return existingRequest;
        }
    }
}
