using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using API.Models;
using API.Data;
using API.Dtos.User;
using API.Helpers;

namespace API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(o => o.Offers)
                .Include(r => r.Requests)
                .ToListAsync();
        }
        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _context.Users                
                .Include(o => o.Offers)
                .Include(r => r.Requests)
                .FirstOrDefaultAsync(i => i.UserId == userId);
        }
        public async Task<User> CreateAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> DeleteAsync (int userId)
        {
            var userModel = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);
            
            if(userModel == null)
            {
                return null;
            }

            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public Task<bool> UserExist(int userId)
        { 
            return _context.Users
                .AnyAsync(u => u.UserId == userId);
        }
        public async Task<User?> UpdateAsync (int userId, UpdateUserRequestDto userDto)
        {
            var existingUser = await _context.Users.FindAsync(userId);

            if(existingUser == null)
                return null;
            
            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            existingUser.Email = userDto.Email;
            existingUser.PasswordHash = userDto.PasswordHash;
            existingUser.Address = userDto.Address;
            existingUser.City = userDto.City;
            existingUser.PostNumber = userDto.PostNumber;

            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}
