using API.Models;
using API.Helpers;

namespace API.Interfaces
{
    public interface IRequestRepository
    {
        Task<List<Request>> GetAllAsync(RequestQueryObject query);
        Task<Request?> GetByIdAsync(int requestId);
        Task<Request> CreateAsync(Request requestModel);
        Task<Request?> UpdateAsync(int requestId, Request requestModel);
        Task<Request?> DeleteAsync (int requestId);
        Task<bool> RequestExist(int requestId);
        Task<bool> UserCanCreateRequest(int requestId, int userId);
    }
}
