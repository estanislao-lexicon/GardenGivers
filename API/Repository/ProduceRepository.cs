using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFramworkCore;
using API.Interfaces;
using API.Models;
using API.Data;
using API.Dtos.Produce;
using API.Helpers;


namespace API.Repository
{
    public class ProduceRepository : IProduceRepository
    {
        private readonly ApplicationDBContext _context;

        public ProduceRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Produce>> GetAllAsync(QueryObject query)
        {
            return await _context.Produces.ToListAsync();
        }
        public async Task<Produce?> GetByIdAsync(int produceId)
        {
            return await _context.Produces.Include(p => p.produceId).FirstOrDefaultAsync(i => i.ProduceId == produceId);
        }
        public async Task<Produce> CreateAsync(Produce produceModel)
        {
            await _context.Produces.AddAsync(produceModel);
            await _context.SaveChangesAsync();
            return produceModel;
        }

        public async Task<Produce?> DeleteAsync (int produceId)
        {
            var produceModel = await _context.Produces.FirstOrDefaultAsync(p => p.ProduceId = produceId);
            
            if(produceModel == null)
            {
                return null;
            }

            _context.Produces.Remove(produceModel);
            await _context.SaveChangesAsync();
            return produceModel;
        }

        public Task<bool> ProduceExists(int produceId)
        { 
            return _context.Produce.AnyAsync(p => p.ProduceId == produceId);
        }
        public async Task<Produce?> UpdateAsync (int produceId, UpdateProduceRequestDto produceDto)
        {
            var existingProduce = await _context.Produce.FirstOrDefaultAsync(p => p.ProduceId == produceId);

            if(existingProduce == null)
            {
                return null;
            }

            existingProduce.Name = produceDto.Name;
            existingProduce.Description = produceDto.Description;

            await _context.SaveChangesAsync();
            return existingProduce;
        }
    }
}
