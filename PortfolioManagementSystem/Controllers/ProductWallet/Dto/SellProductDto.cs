using System.Text.Json.Serialization;

namespace PortfolioManagementSystem.Controllers.ProductWallet.Dto
{
    public class SellProductDto
    {
        [JsonPropertyName("productWalletId")]
        public Guid ProductWalletId { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
