using Domain.Product.Service;
using Domain.ProductWallet.Service;
using Domain.Wallet.Service;
using Domain.WalletTransaction.Entity;
using Domain.WalletTransaction.Service;
using Microsoft.AspNetCore.Mvc;
using PortfolioManagementSystem.Controllers.ProductWallet.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace PortfolioManagementSystem.Controllers.WalletTransaction.Http
{
    [Route("api/[controller]")]
    [SwaggerTag("Endpoints to manage wallet transactions")]
    [Produces("application/json")]
    public class WalletTransactionController : Controller
    {
        private readonly IWalletTransactionService _service;

        public WalletTransactionController(IWalletTransactionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Add Wallet Transaction
        /// </summary>
        /// <param name="dto">Buy new Product</param>
        /// <response code="204">Product sucessfully buyed</response>
        /// <response code="400">Bad Request</response>
        [HttpPost("add/{dto}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddProduct([FromRoute] string dto)
        {
            WalletTransactionEntity entity = new WalletTransactionEntity
            {
                //Description = dto,
                Id = Guid.NewGuid()
            };

            await _service.AddTransaction(entity);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        /// get Wallet Transaction by id
        /// </summary>
        /// <param name="dto">Buy new Product</param>
        /// <response code="204">Product sucessfully buyed</response>
        /// <response code="400">Bad Request</response>
        [HttpPost("get/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var trans = await _service.GetById(id);

            return StatusCode(200, trans);
        }
    }
}
