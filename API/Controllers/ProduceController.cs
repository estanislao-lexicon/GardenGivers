using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using API.Dtos.Produce;
using API.Interfaces;
using API.Models;
using API.Data;
using API.Helper;
using API.Mappers;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IProduceRepository _produceRepository;

        private ProduceController(ApplicationDBContext context, IProduceRepository produceRepository)
        {
            _context = context;
            _produceRepository = produceRepository;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var produces = await _produceRepository.GetAllAsync(query);
            
            var produceDto = produces.Select(p => p.ToProduceDto().ToList());

            return Ok(produceDto);
        }

        [HttpGet("{produceId:int}")]        
        public async Task<IActionResult> GetById([FromRoute] int produceId)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);    
            
            var produce = await _produceRepository.GetByIdAsync(produceId);

            if (produce == null)
            {
                return NotFound();
            }

            return Ok(produce.ToProduceDto());
        }      

        [HttpPost]        
        public async Task<IActionResult> Create([FromBody] CreateProduceDto produceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var produceModel = produceDto.ToProduceFromCreateDto();
            
            await _produceRepository.CreateAsync(produceModel);

            return CreatedAtAction(nameof(GetById), new { id = produceModel.produceId }, produceModel.ToProduceDto());
        }

        [HttpPut]
        [Route("{produceId:int}")]
        public async Task<IActionResult> Update([FromRoute] int produceId, [FromBody] UpdateProduceRequestDto produceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var produceModel = await _produceRepository.UpdateAsync(produceId, updatedDto);
            
            if(produceModel == null)
            {
                return NotFound();
            }            

            return Ok(produceModel.ToProduceDto());
        }

        [HttpDelete]
        [Route("{produceId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int produceId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var produceModel = await _produceRepository.DeleteAsync(produceId);

            if (produceModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
