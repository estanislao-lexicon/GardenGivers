using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Helpers;
using API.Dtos.User;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int userId);
        Task<User> CreateAsync(User userModel);
        Task<User?> UpdateAsync(int userId, UpdateUserRequestDto userDto);
        Task<User?> DeleteAsync (int userId);
        Task<bool> UserExists(int userId);
    }
}
