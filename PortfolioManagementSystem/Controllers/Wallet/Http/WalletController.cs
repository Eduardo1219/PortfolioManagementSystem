using Domain.Product.Entity;
using Domain.User.Entity.Enum;
using Domain.User.Entity;
using Domain.User.Service;
using Domain.Wallet.Service;
using Microsoft.AspNetCore.Mvc;
using PortfolioManagementSystem.Controllers.Users.Dto;
using PortfolioManagementSystem.Helpers.Mappers;
using Swashbuckle.AspNetCore.Annotations;
using Domain.ProductWallet.Service;
using PortfolioManagementSystem.Controllers.Wallet.Dto;
using Domain.Schedule;
using Hangfire;

namespace PortfolioManagementSystem.Controllers.Wallet.Http
{
    [Route("api/[controller]")]
    [SwaggerTag("Endpoints to manage the wallet")]
    [Produces("application/json")]
    public class WalletController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWalletService _walletService;
        private readonly IProductWalletService _productWalletService;

        public WalletController(IUserService userService,
            IWalletService walletService,
            IProductWalletService productWalletService)
        {
            _userService = userService;
            _walletService = walletService;
            _productWalletService = productWalletService;
        }

        /// <summary>
        /// Get user wallet
        /// </summary>
        /// <param name="id">User Id</param>
        /// <response code="200">User wallet</response>
        /// <response code="400">Bad Request</response>
        [HttpGet("userId/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUserWallet([FromRoute] Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return StatusCode(StatusCodes.Status404NotFound, "User not found");

            var wallet = await _walletService.GetWalletByUserIdAsync(id);

            if (wallet == null)
                return StatusCode(StatusCodes.Status404NotFound, "Wallet not found");

            return StatusCode(StatusCodes.Status200OK, wallet);
        }

        /// <summary>
        /// Get wallet products by wallet id
        /// </summary>
        /// <param name="Id">Wallet Id</param>
        /// <response code="200">Products</response>
        /// <response code="404">Not Found</response>
        [HttpGet("walletId/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetWalletProducts([FromRoute] Guid id)
        {
            var wallet = await _walletService.GetWalletByIdAsync(id);

            if (wallet == null)
                return StatusCode(StatusCodes.Status404NotFound, "wallet not found");

            var products = await _productWalletService.GetProductByWalletId(id);

            if (!products.Any())
                return StatusCode(StatusCodes.Status404NotFound, "any products was found in the wallet");

            return StatusCode(StatusCodes.Status200OK, products);
        }

        /// <summary>
        /// Make Transaction
        /// </summary>
        /// <param name="id">Wallet Id</param>
        /// <response code="201">Transaction Succesfully</response>
        /// <response code="404">Not Found</response>
        [HttpPost("transaction/{id}")]
        [ProducesResponseType(typeof(UserEntity), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById([FromRoute] Guid id,[FromBody] WalletTransactionDto transactionDto)
        {
            var wallet = await _walletService.GetWalletByIdAsync(id);

            if (wallet == null)
                return StatusCode(StatusCodes.Status404NotFound, "wallet not found");

            var transaction = WalletTransactionMapper.WalletTransactionEntityMapper(wallet, transactionDto.Amount, transactionDto.OperationType);

            wallet.UpdateBalance(transactionDto.Amount, transaction.ModificationType);
            await _walletService.UpdateWalletAsync(wallet);

            BackgroundJob.Enqueue<ISchedule>(s => s.AddTransaction(transaction, wallet.Id, transaction.OperationDate.Month));

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
