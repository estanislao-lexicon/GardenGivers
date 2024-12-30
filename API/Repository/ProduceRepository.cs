using API.Interfaces;
using API.Models;
using API.Data;


namespace API.Repository
{
    public class ProduceRepository : IProduceRepository
    {
        private readonly ApplicationDBContext _context;

        public ProduceRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool CreateProduce(Produce produce)
        {
            _context.Add(produce);
            return Save();        }

        public bool DeleteProduce(Produce produce)
        {
            _context.Remove(produce);
            return Save();
        }

        public Produce GetProduce(int produceId)
        {
            return _context.Produces.Where(p => p.ProduceId == produceId).FirstOrDefault();
        }

        public ICollection<Produce> GetProduces()
        {
            return _context.Produces.ToList();
        }

        public bool ProduceExists(int produceId)
        {
            return _context.Produces.Any(p => p.ProduceId == produceId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateProduce(Produce produce)
        {
            _context.Update(produce);
            return Save();
        }
    }
}
