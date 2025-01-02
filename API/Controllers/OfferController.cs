using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using API.Dtos.Offer;
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
        private readonly IOfferRepository _offerRepository;

        private OfferController(ApplicationDBContext context, IOfferRepository offerRepository)
        {
            _context = context;
            _offerRepository = offerRepository;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var offers = await _offerRepository.GetAllAsync(query);
            
            var offerDto = offers.Select(o => o.ToOfferDto().ToList());

            return Ok(offerDto);
        }

        [HttpGet("{offerId:int}")]        
        public async Task<IActionResult> GetById([FromRoute] int offerId)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);    
            
            var offer = await _offerRepository.GetByIdAsync(offerId);

            if (offer == null)
            {
                return NotFound();
            }

            return Ok(offer.ToOfferDto());
        }      

        [HttpPost]        
        public async Task<IActionResult> Create([FromBody] CreateOfferDto offerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var offerModel = offerDto.ToOfferFromCreateDto();
            
            await _offerRepository.CreateAsync(offerModel);

            return CreatedAtAction(nameof(GetById), new { id = offerModel.offerId }, offerModel.ToOfferDto());
        }

        [HttpPut]
        [Route("{offerId:int}")]        
        public async Task<IActionResult> Update([FromRoute] int offerId, [FromBody] UpdateOfferRequestDto updatedDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var offerModel = await _offerRepository.UpdateAsync(offerId, updatedDto);
            
            if(offerModel == null)
            {
                return NotFound();
            }            

            return Ok(offerModel.ToOfferDto());
        }

        [HttpDelete]
        [Route("{offerId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int offerId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var offerModel = await _offerRepository.DeleteAsync(offerId);

            if (offerModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
