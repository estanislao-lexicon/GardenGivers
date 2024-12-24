using API.Interfaces;
using API.Models;
using API.Data;

namespace API.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DataContext _context;

        public RequestRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateRequest(Request request)
        {
           _context.Add(request);
            return Save();
        }

        public bool DeleteRequest(Request request)
        {
            _context.Remove(request);
            return Save();
        }       

        public Request GetRequest(int requestId)
        {
            return _context.Requests.Where(r => r.RequestId == requestId).FirstOrDefault();
        }

        public ICollection<Request> GetRequests()
        {
            return _context.Requests.ToList();
        }

        public bool RequestExists(int requestId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateRequest(Request request)
        {
            _context.Update(request);
            return Save();
        }
    }
}
