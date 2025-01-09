using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Dtos.Account;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [Route("api/account")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if(user == null)
                return Unauthorized("Invalid username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(!result.Succeeded)
                return Unauthorized("Username not found and/or password is incorrect");

            return Ok(
                new NewUserDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    City = user.City,
                    Address = user.Address,
                    PostNumber = user.PostNumber
                }
            );            
        }  

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
           try 
           {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = new User
                {
                     UserName = registerDto.Username,
                     Email = registerDto.Email,
                     FirstName = registerDto.FirstName,
                     LastName = registerDto.LastName,
                     City = registerDto.City,
                     Address = registerDto.Address,
                     PostNumber = registerDto.PostNumber,
                     Offers = new List<Offer>(),
                     Requests = new List<Request>()
                };
    
                var createUser = await _userManager.CreateAsync(user, registerDto.Password);
    
                if(createUser.Succeeded)
                {
                     var roleResult = await _userManager.AddToRoleAsync(user, "User");
                     if(roleResult.Succeeded)
                     {
                        return Ok(
                            new NewUserDto
                            {
                                Username = user.UserName,
                                Email = user.Email,
                                Token = _tokenService.CreateToken(user),
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                City = user.City,
                                Address = user.Address,
                                PostNumber = user.PostNumber
                            }
                        );
                     }
                     else
                     {
                        return StatusCode(500, roleResult.Errors);
                     }
                }
                else
                {
                    return StatusCode(500, createUser.Errors);
                }
              }
              catch(Exception e)
              {
                return StatusCode(500, e);
           }
        }

    }
}