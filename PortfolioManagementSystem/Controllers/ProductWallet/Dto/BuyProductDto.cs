using System.Text.Json.Serialization;

namespace PortfolioManagementSystem.Controllers.ProductWallet.Dto
{
    public class BuyProductDto
    {
        [JsonPropertyName("WalletId")]
        public Guid WalletId { get; set; }
        [JsonPropertyName("ProductId")]
        public Guid ProductId { get; set; }
        [JsonPropertyName("Quantity")]
        public int Quantity {  get; set; }
    }
}
