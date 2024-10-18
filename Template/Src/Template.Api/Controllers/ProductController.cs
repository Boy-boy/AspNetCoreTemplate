using Core.Uow;
using Microsoft.AspNetCore.Mvc;
using Template.Application;
using Template.Infrastructure.Dtos;

namespace Template.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [UnitOfWork(false)]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
        {
            await _productService.CreateProduct(productDto);
            return Ok();
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] UpdateProductDto productDto)
        {
            await _productService.UpdateProduct(productId, productDto);
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            await _productService.DeleteProduct(productId);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }
    }
}
