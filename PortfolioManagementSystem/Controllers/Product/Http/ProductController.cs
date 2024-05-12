using Domain.Product.Entity;
using Domain.Product.Service;
using Microsoft.AspNetCore.Mvc;
using PortfolioManagementSystem.Controllers.Product.Dto;
using PortfolioManagementSystem.Helpers.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace PortfolioManagementSystem.Controllers.Product.Http
{
    [Route("api/[controller]")]
    [SwaggerTag("Endpoints to manage products")]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="dto">New Product</param>
        /// <response code="201">Product sucessfully added</response>
        /// <response code="400">Bad Request</response>
        [HttpPost("")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            var product = dto.MapProductEntity();
            await _productService.AddProductAsync(product);

            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="dto">Product</param>
        /// <param name="Id">Product Id</param>
        /// <response code="204">Product sucessfully Updated</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto dto, [FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            var productEntity = await _productService.GetProductByIdAsync(id);

            if (productEntity == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Product not found");
            }

            var entityUpdated = ProductMapper.MapUpdateEntity(productEntity, dto);
            await _productService.UpdateProductAsync(entityUpdated);

            return StatusCode(StatusCodes.Status204NoContent, dto);
        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <response code="200">Product</response>
        /// <response code="404">Not Found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductEntity), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var productEntity = await _productService.GetProductByIdAsync(id);

            if (productEntity == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Product not found");
            }

            return StatusCode(StatusCodes.Status200OK, productEntity);
        }

        /// <summary>
        /// Get count products
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <response code="200">Count Products</response>
        /// <response code="404">Not Found</response>
        [HttpGet("count")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCount([FromHeader] decimal? price,
            [FromHeader] DateTime? dueDate,
            [FromHeader] bool? active)
        {
            var productCount = await _productService.GetCountAsync(price, dueDate, active);

            return StatusCode(StatusCodes.Status200OK, new { Count = productCount });
        }

        /// <summary>
        /// Get paged filter products
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <response code="200">Count Products</response>
        /// <response code="404">Not Found</response>
        [HttpGet("filter")]
        [ProducesResponseType(typeof(List<ProductEntity>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetProductsPagedFilter([FromHeader] decimal? price,
            [FromHeader] DateTime? dueDate,
            [FromHeader] bool? active,
            [FromHeader] int take = 5,
            [FromHeader] int skip = 0)
        {
            var products = await _productService.GetPagedAsync(take, skip, price, dueDate, active);

            return StatusCode(StatusCodes.Status200OK, products);
        }
    }
}
