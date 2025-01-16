using Microsoft.AspNetCore.Mvc;
using API.Dtos.Offer;
using API.Interfaces;
using API.Data;
using API.Helpers;
using API.Mappers;


namespace API.Controllers
{
    [Route("api/offer")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IOfferRepository _offerRepository;        
        private readonly IProductRepository _productRepository;

        public OfferController(ApplicationDbContext context, IOfferRepository offerRepository, IProductRepository productRepository)
        {
            _context = context;
            _offerRepository = offerRepository;            
            _productRepository = productRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OfferQueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var offers = await _offerRepository.GetAllAsync(query);
                                                
            var offerDto = offers.Select(o => o.ToOfferDto());

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
        [Route("{productId:int}")]
        public async Task<IActionResult> Create([FromRoute] int productId, CreateOfferDto offerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);  

            var userId = User.FindFirst("UserId")?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User ID is missing.");
            
            if(!await _productRepository.ProductExist(productId))
                return NotFound($"Product with ID {productId} not found.");
            
            // Check if the user already has an offer for this product
            var existingOffer = await _offerRepository.GetOfferByUserAndProductAsync(userId, productId);
            if (existingOffer != null)
                return Conflict("You already have an offer for this product.");
            
            if (offerDto.IsFree && offerDto.Price > 0)
                return BadRequest("Free offers cannot have a price.");

            if (offerDto.ExpirationDate <= DateTime.UtcNow)
                return BadRequest("Expiration date must be in the future.");

            var offerModel = offerDto.ToOfferFromCreate(userId, productId);
            
            await _offerRepository.CreateAsync(offerModel);

            return CreatedAtAction(nameof(GetById), new { offerId = offerModel.OfferId }, offerModel.ToOfferDto());
        }

        [HttpPut]
        [Route("{offerId:int}")]     
        public async Task<IActionResult> Update([FromRoute] int offerId, [FromBody] UpdateOfferRequestDto updatedDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // Fetch the existing offer from the database using the offerId
            var existingOffer = await _offerRepository.GetByIdAsync(offerId); 

            var offerModel = await _offerRepository.UpdateAsync(offerId, updatedDto.ToOfferFromUpdate(existingOffer));
            
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
            
            var userId = User.FindFirst("UserId")?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User ID is missing.");
            
            var existingOffer = await _offerRepository.GetByIdAsync(offerId);
            if (existingOffer.UserId != userId)
                return Forbid("You cannot delete an offer from another user.");

            var offerModel = await _offerRepository.DeleteAsync(offerId);

            if (offerModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
