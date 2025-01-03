using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using API.Dtos.Transaction;
using API.Interfaces;
using API.Models;
using API.Data;
using API.Helper;
using API.Mappers;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IRequestRepository _requestRepository;

        private TransactionController(ApplicationDBContext context, ITransactionRepository transactionRepository, IOfferRepository offerRepository, IRequestRepository requestRepository)
        {
            _context = context;
            _transactionRepository = transactionRepository;
            _offerRepository = offerRepository;
            _requestRepository = requestRepository;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactions = await _transactionRepository.GetAllAsync(query);
            
            var transactionDto = transactions.Select(t => t.ToTransactionDto().ToList());

            return Ok(transactionDto);
        }

        [HttpGet("{transactionId:int}")]        
        public async Task<IActionResult> GetById([FromRoute] int transactionId)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);    
            
            var transaction = await _transactionRepository.GetByIdAsync(transactionId);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction.ToTransactionDto());
        }      

        [HttpPost]
        [Route("{offerId:int, requestId:int}")]
        public async Task<IActionResult> Create([FromRoute] int offerId, int requestId, CreateTransactionDto transactionDto)
        {
            if(!await _offerRepository.OfferExist(offerId))
                return BadRequest("Offer does not exist");
            
            if(!await _requestRepository.RequestExist(requestId))
                return BadRequest("Request does not exist");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactionModel = transactionDto.ToTransactionFromCreateDto(offerId, requestId);
            
            await _transactionRepository.CreateAsync(transactionModel);

            return CreatedAtAction(nameof(GetById), new { id = transactionModel.transactionId }, transactionModel.ToTransactionDto());
        }

        [HttpPut]
        [Route("{transactionId:int}")]
        public async Task<IActionResult> Update([FromRoute] int transactionId, [FromBody] UpdateTransactionRequestDto updatedDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var transactionModel = await _transactionRepository.UpdateAsync(transactionId, updatedDto.ToTransactionFromUpdate());
            
            if(transactionModel == null)
            {
                return NotFound("Transaction not found");
            }            

            return Ok(transactionModel.ToTransactionDto());
        }

        [HttpDelete]
        [Route("{transactionId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int transactionId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactionModel = await _transactionRepository.DeleteAsync(transactionId);

            if (transactionModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
