using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using API.Dtos.User;
using API.Interfaces;
using API.Models;
using API.Data;
using API.Helpers;
using API.Mappers;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;    
        private readonly IUserRepository _userRepository;        

        public UserController(ApplicationDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;            
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var users = await _userRepository.GetAllAsync();
            var userDto = users.Select(u => u.ToUserDto());

            return Ok(userDto);
        }

        [HttpGet("{userId:int}")]
        
        public async Task<IActionResult> GetById([FromRoute] int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.GetByIdAsync(userId);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }      

        [HttpPost]
        
        public async Task<IActionResult> Create([FromBody] CreateUserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userModel = userDto.ToUserFromCreate();

            await _userRepository.CreateAsync(userModel);

            return CreatedAtAction(nameof(GetById), new { id = userModel.UserId }, userModel.ToUserDto());
        }

        [HttpPut]
        [Route("{userId:int}")]
        public async Task<IActionResult> Update([FromRoute] int userId, [FromBody] UpdateUserRequestDto updatedDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userModel = await _userRepository.UpdateAsync(userId, updatedDto);

            if(userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel.ToUserDto());
        }

        [HttpDelete]
        [Route("{userId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userModel = await _userRepository.DeleteAsync(userId);

            if (userModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
