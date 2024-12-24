using API.Models;

namespace API.Interfaces
{
    public interface IRequestRepository
    {
        ICollection<Request> GetRequests();
        Request GetRequest(int requestId);        
        bool RequestExists(int requestId);
        bool CreateRequest(Request request);
        bool UpdateRequest(Request request);
        bool DeleteRequest(Request request);
        bool Save();
    }
}
