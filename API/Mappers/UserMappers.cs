using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Task;
using API.Models;
using API.Dtos.User;

namespace API.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                UserId = userModel.UserId,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                PasswordHash = userModel.PasswordHash,
                City = userModel.City,
                Address = userModel.Address,
                PostNumber = userModel.PostNumber,
                DateCreated = userModel.DateCreated,
                Offers = userModel.Offers,
                Requests = userModel.Requests,
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto)
        {
            return new User
            {
                UserId = userDto.UserId,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PasswordHash = userDto.PasswordHash,
                City = userDto.City,
                Address = userDto.Address,
                PostNumber = userDto.PostNumber,
                DateCreated = userDto.DateCreated,
                Offers = userDto.Offers,
                Requests = userDto.Requests,           
            };
        }
    }
}
