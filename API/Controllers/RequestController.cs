using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using API.Dtos.Request;
using API.Interfaces;
using API.Models;
using API.Data;
using API.Helper;
using API.Mappers;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IRequestRepository _requestRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        private RequestController(ApplicationDBContext context, IRequestRepository requestRepository, IUserRepository userRepository, IProductRepository productRepository)
        {
            _context = context;
            _requestRepository = requestRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var requests = await _requestRepository.GetAllAsync(query);
            
            var requestDto = requests.Select(r => r.ToRequestDto().ToList());

            return Ok(requestDto);
        }

        [HttpGet("{requestId:int}")]        
        public async Task<IActionResult> GetById([FromRoute] int requestId)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);    
            
            var request = await _requestRepository.GetByIdAsync(requestId);

            if (request == null)
            {
                return NotFound();
            }

            return Ok(request.ToRequestDto());
        }      

        [HttpPost]
        [Route("{userId:int, productId:int }")]      
        public async Task<IActionResult> Create([FromRoute] int userId, int productId, CreateRequestDto requestDto)
        {
            if(!await _userRepository.UserExist(userId))
                return BadRequest("User does not exist");
            
            if(!await _productRepository.ProductExist(productId))
                return BadRequest("Product does not exist");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var requestModel = requestDto.ToRequestFromCreateDto(userId, productId);
            
            await _requestRepository.CreateAsync(requestModel);

            return CreatedAtAction(nameof(GetById), new { id = requestModel.requestId }, requestModel.ToRequestDto());
        }

        [HttpPut]
        [Route("{requestId:int}")]
        public async Task<IActionResult> Update([FromRoute] int requestId, [FromBody] UpdateRequestRequestDto updatedDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var requestModel = await _requestRepository.UpdateAsync(requestId, updatedDto.ToOfferFromUpdate());
            
            if(requestModel == null)
            {
                return NotFound("Request not found");
            }            

            return Ok(requestModel.ToRequestDto());
        }

        [HttpDelete]
        [Route("{requestId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int requestId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var requestModel = await _requestRepository.DeleteAsync(requestId);

            if (requestModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
