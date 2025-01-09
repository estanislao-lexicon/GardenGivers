using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Dtos.Request;
using API.Interfaces;
using API.Data;
using API.Helpers;
using API.Mappers;


namespace API.Controllers
{
    [Route("api/request")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IRequestRepository _requestRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOfferRepository _offerRepository;

        public RequestController(ApplicationDbContext context, IRequestRepository requestRepository, IUserRepository userRepository, IOfferRepository offerRepository)
        {
            _context = context;
            _requestRepository = requestRepository;
            _userRepository = userRepository;
            _offerRepository = offerRepository;
        }
        
        [HttpGet]        
        public async Task<IActionResult> GetAll([FromQuery] RequestQueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var requests = await _requestRepository.GetAllAsync(query);
            
            var requestDto = requests.Select(r => r.ToRequestDto());

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
        [Route("{userId:int}/{offerId:int}")]
        public async Task<IActionResult> Create([FromRoute] int userId, int offerId, CreateRequestDto requestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _userRepository.UserExist(userId))
                return BadRequest("User does not exist or is invalid");
            
            if(!await _offerRepository.OfferExist(offerId))
                return BadRequest("Offer does not exist or is invalid");

            if (!await _requestRepository.UserCanCreateRequest(offerId, userId))
                return BadRequest("You cannot create a request for your own offer.");

            var requestModel = requestDto.ToRequestFromCreate(userId, offerId);
            
            await _requestRepository.CreateAsync(requestModel);

            return CreatedAtAction(nameof(GetById), new { requestId = requestModel.RequestId }, requestModel.ToRequestDto());
        }

        [HttpPut]
        [Route("{userId:int}/{requestId:int}")]
        public async Task<IActionResult> Update([FromRoute] int userId, int requestId, [FromBody] UpdateRequestDto updatedDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var requestModel = await _requestRepository.UpdateAsync(requestId, updatedDto.ToRequestFromUpdate(userId, requestId));
            
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
