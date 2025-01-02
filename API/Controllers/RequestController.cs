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

        private RequestController(ApplicationDBContext context, IRequestRepository requestRepository)
        {
            _context = context;
            _requestRepository = requestRepository;
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
        public async Task<IActionResult> Create([FromBody] CreateRequestDto requestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var requestModel = requestDto.ToRequestFromCreateDto();
            
            await _requestRepository.CreateAsync(requestModel);

            return CreatedAtAction(nameof(GetById), new { id = requestModel.requestId }, requestModel.ToRequestDto());
        }

        [HttpPut]
        [Route("{requestId:int}")]
        public async Task<IActionResult> Update([FromRoute] int requestId, [FromBody] UpdateRequestRequestDto updatedDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var requestModel = await _requestRepository.UpdateAsync(requestId, updatedDto);
            
            if(requestModel == null)
            {
                return NotFound();
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
