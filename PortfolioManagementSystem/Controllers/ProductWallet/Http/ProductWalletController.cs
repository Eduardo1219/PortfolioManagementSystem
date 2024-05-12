using Domain.Product.Entity;
using Domain.Product.Service;
using Domain.ProductWallet.Service;
using Domain.Schedule;
using Domain.User.Service;
using Domain.Wallet.Service;
using Domain.WalletTransaction.Entity;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using PortfolioManagementSystem.Controllers.Product.Dto;
using PortfolioManagementSystem.Controllers.ProductWallet.Dto;
using PortfolioManagementSystem.Helpers.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace PortfolioManagementSystem.Controllers.ProductWallet.Http
{
    [Route("api/[controller]")]
    [SwaggerTag("Endpoints to manage wallet products")]
    [Produces("application/json")]
    public class ProductWalletController : Controller
    {
        private readonly IProductWalletService _service;
        private readonly IWalletService _walletService;
        private readonly IProductService _productService;

        public ProductWalletController(IProductWalletService service,
            IWalletService walletService,
            IProductService productService)
        {
            _service = service;
            _walletService = walletService;
            _productService = productService;
        }

        /// <summary>
        /// Buy a new product
        /// </summary>
        /// <param name="dto">Buy new Product</param>
        /// <response code="204">Product sucessfully buyed</response>
        /// <response code="400">Bad Request</response>
        [HttpPost("buy")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddProduct([FromBody] BuyProductDto dto)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);

            var product = await _productService.GetProductByIdAsync(dto.ProductId);
            if (product == null)
                return StatusCode(StatusCodes.Status400BadRequest, "Product not found or not exist");

            var wallet = await _walletService.GetWalletByIdAsync(dto.WalletId);
            if (wallet == null)
                return StatusCode(StatusCodes.Status400BadRequest, "Wallet not found or not exist");

            var totalValue = product.Price * dto.Quantity;
            var sufficientBalance = wallet.ValidateBalance(totalValue);
            if (!sufficientBalance)
                return StatusCode(StatusCodes.Status400BadRequest, "Insufficient balance to perform the transaction");

            var transaction = WalletTransactionMapper.WalletTransactionEntityMapper(wallet, totalValue, OperationType.Buy);

            await _service.BuyProduct(wallet, product, dto.Quantity);

            wallet.UpdateInvestedBalance(totalValue, transaction.OperationType);
            wallet.UpdateBalance(totalValue, transaction.ModificationType);

            await _walletService.UpdateWalletAsync(wallet);

            BackgroundJob.Enqueue<ISchedule>(s => s.AddTransaction(transaction));

            return StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        /// Sell Products
        /// </summary>
        /// <param name="dto">Sell Products</param>
        /// <response code="204">Products sucessfully sold</response>
        /// <response code="400">Bad Request</response>
        [HttpPost("sell")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddPraoduct([FromBody] SellProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            var productWallet = await _service.GetById(dto.ProductWalletId);

            if (productWallet == null)
                return StatusCode(StatusCodes.Status400BadRequest, "Product not found or already sold");

            if (dto.Quantity > productWallet.Quantity)
                return StatusCode(StatusCodes.Status400BadRequest, "You dont have enough products to sell");

            var wallet = await _walletService.GetWalletByIdAsync(productWallet.WalletId);
            if (wallet == null)
                return StatusCode(StatusCodes.Status400BadRequest, "Wallet not found or not exist");

            var product = await _productService.GetProductByIdAsync(productWallet.ProductId);
            if (product == null)
                return StatusCode(StatusCodes.Status400BadRequest, "Product not found or not exist");

            var totalValue = product.Price * dto.Quantity;

            var transaction = WalletTransactionMapper.WalletTransactionEntityMapper(wallet, totalValue, OperationType.Sell);

            await _service.UpdateProductWallet(productWallet, dto.Quantity * -1);

            wallet.UpdateInvestedBalance(totalValue, transaction.OperationType);
            wallet.UpdateBalance(totalValue, transaction.ModificationType);

            await _walletService.UpdateWalletAsync(wallet);

            BackgroundJob.Enqueue<ISchedule>(s => s.AddTransaction(transaction));

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
