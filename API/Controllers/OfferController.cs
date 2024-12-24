using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dto;
using API.Interfaces;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : Controller
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public OfferController(IOfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Offer>))]
        public IActionResult GetOffers()
        {
            var offers = _mapper.Map<List<OfferDto>>(_offerRepository.GetOffers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(offers);
        }

        [HttpGet("{offerId}")]
        [ProducesResponseType(200, Type = typeof(Offer))]
        [ProducesResponseType(400)]
        public IActionResult GetOffer(int offerId)
        {
            if (!_offerRepository.OfferExists(offerId))
                return NotFound();

            var offer = _mapper.Map<OfferDto>(_offerRepository.GetOffer(offerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(offer);
        }      

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOffer([FromBody] OfferDto offerCreate)
        {
            if (offerCreate == null)
                return BadRequest(ModelState);

            var offer = _offerRepository.GetOffers()
                .Where(o => o.Quantity == offerCreate.Quantity)
                .FirstOrDefault();

            if(offer != null)
            {
                ModelState.AddModelError("", "Offer already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var offerMap = _mapper.Map<Offer>(offerCreate);

            if(!_offerRepository.CreateOffer(offerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{offerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOffer(int offerId, [FromBody]OfferDto updatedOffer)
        {
            if (updatedOffer == null)
                return BadRequest(ModelState);

            if (offerId != updatedOffer.OfferId)
                return BadRequest(ModelState);

            if (!_offerRepository.OfferExists(offerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var offerMap = _mapper.Map<Offer>(updatedOffer);

            if(!_offerRepository.UpdateOffer(offerMap))
            {
                ModelState.AddModelError("", "Something went wrong updating offer");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{offerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOffer(int offerId)
        {
            if(!_offerRepository.OfferExists(offerId))
            {
                return NotFound();
            }

            var offerToDelete = _offerRepository.GetOffer(offerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_offerRepository.DeleteOffer(offerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting offer");
            }

            return NoContent();
        }
    }
}
