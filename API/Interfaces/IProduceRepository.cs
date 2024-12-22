using API.Models;

namespace API.Interfaces
{
    public interface IProduceRepository
    {
        ICollection<Produce> GetProduces();
        Produce GetProduce(int produceId);        
        bool ProduceExists(int produceId);
        bool CreateProduce(Produce produce);
        bool UpdateProduce(Produce produce);
        bool DeleteProduce(Produce produce);
        bool Save();
    }
}
