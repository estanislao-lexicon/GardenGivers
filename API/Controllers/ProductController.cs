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
using API.Helpers;
using API.Mappers;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductRepository _productRepository;

        private ProductController(ApplicationDbContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] ProductQueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var products = await _productRepository.GetAllAsync(query);
            
            var productDto = products.Select(p => p.ToProductDto());

            return Ok(productDto);
        }

        [HttpGet("{productId:int}")]        
        public async Task<IActionResult> GetById([FromRoute] int productId)
        {            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);    
            
            var product = await _productRepository.GetByIdAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.ToProductDto());
        }      

        [HttpPost]        
        public async Task<IActionResult> Create([FromBody] CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productModel = productDto.ToProductFromCreate();
            
            await _productRepository.CreateAsync(productModel);

            return CreatedAtAction(nameof(GetById), new { id = productModel.ProductId }, productModel.ToProductDto());
        }

        [HttpPut]
        [Route("{productId:int}")]
        public async Task<IActionResult> Update([FromRoute] int productId, [FromBody] UpdateProductRequestDto updatedDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productModel = await _productRepository.UpdateAsync(productId, updatedDto);
            
            if(productModel == null)
                return NotFound();
            
            return Ok(productModel.ToProductDto());
        }

        [HttpDelete]
        [Route("{productId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int productId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productModel = await _productRepository.DeleteAsync(productId);

            if (productModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
