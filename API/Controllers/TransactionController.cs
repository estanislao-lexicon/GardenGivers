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

        private TransactionController(ApplicationDBContext context, ITransactionRepository transactionRepository)
        {
            _context = context;
            _transactionRepository = transactionRepository;
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
        public async Task<IActionResult> Create([FromBody] CreateTransactionDto transactionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactionModel = transactionDto.ToTransactionFromCreateDto();
            
            await _transactionRepository.CreateAsync(transactionModel);

            return CreatedAtAction(nameof(GetById), new { id = transactionModel.transactionId }, transactionModel.ToTransactionDto());
        }

        [HttpPut]
        [Route("{transactionId:int}")]        
        public async Task<IActionResult> Update([FromRoute] int transactionId, [FromBody] UpdateTransactionRequestDto updatedDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var transactionModel = await _transactionRepository.UpdateAsync(transactionId, updatedDto);
            
            if(transactionModel == null)
            {
                return NotFound();
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
