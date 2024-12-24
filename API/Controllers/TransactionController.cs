using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dto;
using API.Interfaces;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Transaction>))]
        public IActionResult GetTransactions()
        {
            var transactions = _mapper.Map<List<TransactionDto>>(_transactionRepository.GetTransactions());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(transactions);
        }

        [HttpGet("{transactionId}")]
        [ProducesResponseType(200, Type = typeof(Transaction))]
        [ProducesResponseType(400)]
        public IActionResult GetTransaction(int transactionId)
        {
            if (!_transactionRepository.TransactionExists(transactionId))
                return NotFound();

            var transaction = _mapper.Map<TransactionDto>(_transactionRepository.GetTransaction(transactionId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(transaction);
        }      

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTransaction([FromBody] TransactionDto transactionCreate)
        {
            if (transactionCreate == null)
                return BadRequest(ModelState);

            var transaction = _transactionRepository.GetTransactions()
                .Where(t => t.Quantity == transactionCreate.Quantity)
                .FirstOrDefault();

            if(transaction != null)
            {
                ModelState.AddModelError("", "Transaction already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactionMap = _mapper.Map<Transaction>(transactionCreate);

            if(!_transactionRepository.CreateTransaction(transactionMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Transaction successfully created");
        }

        [HttpPut("{transactionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTransaction(int transactionId, [FromBody]UserDto updatedTransaction)
        {
            if (updatedTransaction == null)
                return BadRequest(ModelState);

            if (transactionId != updatedTransaction.UserId)
                return BadRequest(ModelState);

            if (!_transactionRepository.TransactionExists(transactionId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var transactionMap = _mapper.Map<Transaction>(updatedTransaction);

            if(!_transactionRepository.UpdateTransaction(transactionMap))
            {
                ModelState.AddModelError("", "Something went wrong updating transaction");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{transactionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int transactionId)
        {
            if(!_transactionRepository.TransactionExists(transactionId))
            {
                return NotFound();
            }

            var transactionToDelete = _transactionRepository.GetTransaction(transactionId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_transactionRepository.DeleteTransaction(transactionToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting transaction");
            }

            return NoContent();
        }
    }
}
