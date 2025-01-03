using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        private OfferController(ApplicationDBContext context, IOfferRepository offerRepository, IUserRepository userRepository, IProductRepository productRepository)
        {
            _context = context;
            _offerRepository = offerRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
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
        [Route("{userdId:int, productId:int}")]  
        public async Task<IActionResult> Create([FromRoute] int userId, int productId, CreateOfferDto offerDto)
        {
            if(!await _userRepository.UserExist(userId))
                return BadRequest("User does not exist");
            
            if(!await _productRepository.ProductExist(productId))
                return BadRequest("Product does not exist");
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var offerModel = offerDto.ToOfferFromCreateDto(userId, productId);
            
            await _offerRepository.CreateAsync(offerModel);

            return CreatedAtAction(nameof(GetById), new { id = offerModel.offerId }, offerModel.ToOfferDto());
        }

        [HttpPut]
        [Route("{offerId:int}")]     
        public async Task<IActionResult> Update([FromRoute] int offerId, [FromBody] UpdateOfferRequestDto updatedDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var offerModel = await _offerRepository.UpdateAsync(offerId, updatedDto.ToOfferFromUpdate());
            
            if(offerModel == null)
            {
                return NotFound("Offer not found");
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
