using Domain.Product.Service;
using Domain.ProductWallet.Service;
using Domain.Schedule;
using Domain.Wallet.Service;
using Domain.WalletTransaction.Service;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using PortfolioManagementSystem.Controllers.ProductWallet.Dto;
using PortfolioManagementSystem.Helpers.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace PortfolioManagementSystem.Controllers.Transactions.Http
{

    [Route("api/[controller]")]
    [SwaggerTag("Endpoints to manage wallet products")]
    [Produces("application/json")]
    public class TransactionsController : Controller
    {
        private readonly IWalletTransactionService _walletTransactionService;
        private readonly IWalletService _walletService;

        public TransactionsController(IWalletTransactionService walletTransactionService, IWalletService walletService)
        {
            _walletTransactionService = walletTransactionService;
            _walletService = walletService;
        }


        /// <summary>
        /// Get transactions by wallet id
        /// </summary>
        /// <param name="id">Wallet id</param>
        /// <response code="200">Transactions</response>
        /// <response code="400">Bad Request</response>
        [HttpGet("walletId/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddProduct([FromRoute] Guid id)
        {
            var wallet = await _walletService.GetWalletByIdAsync(id);

            if (wallet == null)
                return StatusCode(StatusCodes.Status404NotFound, "wallet not found");

            var transactions = await _walletTransactionService.GetById(id);

            if (!transactions.Any())
                return StatusCode(StatusCodes.Status404NotFound, "transactions not found");

            return StatusCode(StatusCodes.Status200OK, transactions);
        }
    }
}
