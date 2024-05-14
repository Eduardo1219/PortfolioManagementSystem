using Domain.Product.Service;
using Domain.ProductWallet.Service;
using Domain.Schedule;
using Domain.Wallet.Service;
using Domain.WalletTransaction.Service;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using PortfolioManagementSystem.Controllers.ProductWallet.Dto;
using PortfolioManagementSystem.Helpers.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace PortfolioManagementSystem.Controllers.Transactions.Http
{

    [Route("api/[controller]")]
    [SwaggerTag("Endpoints to manage transactions")]
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
        /// Get all transactions by wallet id and period
        /// </summary>
        /// <param name="id">Wallet id</param>
        /// <param name="initialDate">Initial date</param>
        /// <param name="endDate">End date</param>
        /// <response code="200">Transactions</response>
        /// <response code="400">Bad Request</response>
        [HttpGet("walletId/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTransactions(
            [FromRoute] Guid id,
            [FromHeader] DateTime? initialDate,
            [FromHeader] DateTime? endDate)
        {
            var wallet = await _walletService.GetWalletByIdAsync(id);

            if (wallet == null)
                return StatusCode(StatusCodes.Status404NotFound, "wallet not found");

            var transactions = await _walletTransactionService.GetByIdAndPeriod(id, initialDate, endDate);

            if (!transactions.Any())
                return StatusCode(StatusCodes.Status404NotFound, "transactions not found");

            return StatusCode(StatusCodes.Status200OK, transactions);
        }
    }
}
