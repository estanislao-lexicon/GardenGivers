using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dto;
using API.Interfaces;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : Controller
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public RequestController(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Request>))]
        public IActionResult GetRequests()
        {
            var requests = _mapper.Map<List<RequestDto>>(_requestRepository.GetRequests());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(requests);
        }

        [HttpGet("{requestId}")]
        [ProducesResponseType(200, Type = typeof(Request))]
        [ProducesResponseType(400)]
        public IActionResult GetRequest(int requestId)
        {
            if (!_requestRepository.RequestExists(requestId))
                return NotFound();

            var request = _mapper.Map<RequestDto>(_requestRepository.GetRequest(requestId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(request);
        }      

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRequest([FromBody] RequestDto requestCreate)
        {
            if (requestCreate == null)
                return BadRequest(ModelState);

            var request = _requestRepository.GetRequests()
            .Where(r => r.Quantity == requestCreate.Quantity)
                .FirstOrDefault();

            if(request != null)
            {
                ModelState.AddModelError("", "Request already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var requestMap = _mapper.Map<Request>(requestCreate);

            if(!_requestRepository.CreateRequest(requestMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Request successfully created");
        }

        [HttpPut("{requestId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRequest(int requestId, [FromBody]RequestDto updatedRequest)
        {
            if (updatedRequest == null)
                return BadRequest(ModelState);

            if (requestId != updatedRequest.RequestId)
                return BadRequest(ModelState);

            if (!_requestRepository.RequestExists(requestId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var requestMap = _mapper.Map<Request>(updatedRequest);

            if(!_requestRepository.UpdateRequest(requestMap))
            {
                ModelState.AddModelError("", "Something went wrong updating request");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{requestId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRequest(int requestId)
        {
            if(!_requestRepository.RequestExists(requestId))
            {
                return NotFound();
            }

            var requestToDelete = _requestRepository.GetRequest(requestId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_requestRepository.DeleteRequest(requestToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting request");
            }

            return NoContent();
        }
    }
}
