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
        bool DeleteRquest(Request request);
        bool Save();
    }
}
