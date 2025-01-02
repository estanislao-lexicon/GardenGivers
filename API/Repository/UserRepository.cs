using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFramworkCore;
using API.Interfaces;
using API.Models;
using API.Data;
using API.Dtos.User;
using API.Helpers;

namespace API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllAsync(QueryObject query)
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _context.Users.Include(u => u.userId).FirstOrDefaultAsync(i => i.UserId == userId);
        }
        public async Task<User> CreateAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> DeleteAsync (int userId)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(u => u.UserId = userId);
            
            if(userModel == null)
            {
                return null;
            }

            _context.User.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public Task<bool> UserExists(int userId)
        { 
            return _context.Users.AnyAsync(u => u.UserId == userId);
        }
        public async Task<User?> UpdateAsync (int userId, UpdateUserRequestDto userDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if(existingUser == null)
            {
                return null;
            }

            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            existingUser.Email = userDto.Email;
            existingUser.City = userDto.City;
            existingUser.Address = userDto.Address;
            existingUser.PostNumber = userDto.PostNumber;
            existingUser.DateCreated = userDto.DateCreated;            

            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}
