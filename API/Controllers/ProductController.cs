using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using API.Dtos.Product;
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
        private readonly IProductRepository _ProductRepository;

        private ProductController(ApplicationDBContext context, IProductRepository ProductRepository)
        {
            _context = context;
            _ProductRepository = ProductRepository;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Products = await _ProductRepository.GetAllAsync(query);
            
            var ProductDto = Products.Select(p => p.ToProductDto().ToList());

            return Ok(ProductDto);
        }

        [HttpGet("{ProductId:int}")]        
        public async Task<IActionResult> GetById([FromRoute] int ProductId)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);    
            
            var Product = await _ProductRepository.GetByIdAsync(ProductId);

            if (Product == null)
            {
                return NotFound();
            }

            return Ok(Product.ToProductDto());
        }      

        [HttpPost]        
        public async Task<IActionResult> Create([FromBody] CreateProductDto ProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ProductModel = ProductDto.ToProductFromCreateDto();
            
            await _ProductRepository.CreateAsync(ProductModel);

            return CreatedAtAction(nameof(GetById), new { id = ProductModel.ProductId }, ProductModel.ToProductDto());
        }

        [HttpPut]
        [Route("{ProductId:int}")]
        public async Task<IActionResult> Update([FromRoute] int ProductId, [FromBody] UpdateProductRequestDto ProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ProductModel = await _ProductRepository.UpdateAsync(ProductId, updatedDto);
            
            if(ProductModel == null)
                return NotFound();
            
            return Ok(ProductModel.ToProductDto());
        }

        [HttpDelete]
        [Route("{ProductId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int ProductId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ProductModel = await _ProductRepository.DeleteAsync(ProductId);

            if (ProductModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
