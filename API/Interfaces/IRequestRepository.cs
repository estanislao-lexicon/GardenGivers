using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Helpers;
using API.Dtos.Request;

namespace API.Interfaces
{
    public interface IRequestRepository
    {
        Task<List<Request>> GetAllAsync();
        Task<Request?> GetByIdAsync(int requestId);
        Task<Request> CreateAsync(Request requestModel);
        Task<Request?> UpdateAsync(int requestId, UpdateRequestRequestDto requestDto);
        Task<Request?> DeleteAsync (int requestId);
        Task<bool> RequestExists(int requestId);
    }
}
