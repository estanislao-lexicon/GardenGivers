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
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public OfferController(ApplicationDbContext context, IOfferRepository offerRepository, IUserRepository userRepository, IProductRepository productRepository)
        {
            _context = context;
            _offerRepository = offerRepository;
            _userRepository = userRepository;
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
        [Route("{userId:int}/{productId:int}")]
        public async Task<IActionResult> Create([FromRoute] int userId, int productId, CreateOfferDto offerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);  

            if(!await _userRepository.UserExist(userId))
                return BadRequest("User does not exist or is invalid");
            
            if(!await _productRepository.ProductExist(productId))
                return BadRequest("Product does not exist or is invalid");

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
