using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Helpers;
using API.Dtos.Produce;

namespace API.Interfaces
{
    public interface IProduceRepository
    {
        Task<List<Produce>> GetAllAsync();
        Task<Produce?> GetByIdAsync(int produceId);        
        Task<Produce> CreateAsync(Produce produceModel);
        Task<Produce?> UpdateAsync(int produceId, UpdateProduceRequestDto produceDto);
        Task<Produce?> DeleteAsync(int produceId);
        Task<bool> ProduceExists(int produceId);
    }
}
