using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dto;
using API.Interfaces;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduceController : ControllerBase
    {
        private readonly IProduceRepository _produceRepository;
        private readonly IMapper _mapper;

        public ProduceController(IProduceRepository produceRepository, IMapper mapper)
        {
            _produceRepository = produceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Produce>))]
        public IActionResult GetProduces()
        {
            var produces = _mapper.Map<List<ProduceDto>>(_produceRepository.GetProduces());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(produces);
        }

        [HttpGet("{produceId}")]
        [ProducesResponseType(200, Type = typeof(Produce))]
        [ProducesResponseType(400)]
        public IActionResult GetProduce(int produceId)
        {
            if (!_produceRepository.ProduceExists(produceId))
                return NotFound();

            var produce = _mapper.Map<ProduceDto>(_produceRepository.GetProduce(produceId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(produce);
        }      

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduce([FromBody] ProduceDto produceCreate)
        {
            if (produceCreate == null)
                return BadRequest(ModelState);

            var produce = _produceRepository.GetProduces()
                .Where(p => p.Name.Trim().ToUpper() == produceCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if(produce != null)
            {
                ModelState.AddModelError("", "Produce already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var produceMap = _mapper.Map<Produce>(produceCreate);

            if(!_produceRepository.CreateProduce(produceMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Produce successfully created");
        }

        [HttpPut("{produceId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatrProduce(int produceId, [FromBody]UserDto updatedProduce)
        {
            if (updatedProduce == null)
                return BadRequest(ModelState);

            if (produceId != updatedProduce.UserId)
                return BadRequest(ModelState);

            if (!_produceRepository.ProduceExists(produceId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var produceMap = _mapper.Map<Produce>(updatedProduce);

            if(!_produceRepository.UpdateProduce(produceMap))
            {
                ModelState.AddModelError("", "Something went wrong updating produce");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{produceId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProduce(int produceId)
        {
            if(!_produceRepository.ProduceExists(produceId))
            {
                return NotFound();
            }

            var produceToDelete = _produceRepository.GetProduce(produceId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_produceRepository.DeleteProduce(produceToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting produce");
            }

            return NoContent();
        }
    }
}
