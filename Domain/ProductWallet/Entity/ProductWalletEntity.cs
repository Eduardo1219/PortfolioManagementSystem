using Domain.Base.Entity;
using Domain.Product.Entity;
using Domain.Wallet.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProductWallet.Entity
{
    public class ProductWalletEntity : BaseEntity
    {
        [Required]
        public DateTime ProductPurchaseDate { get; set; }
        [Required]
        public decimal ProductValueAtPurchase {  get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime? LastChangeDate { get; set; }
        [Required]
        public Guid WalletId { get; set; }
        public WalletEntity Wallet { get; set; }
        [Required]
        public Guid ProductsId { get; set; }
        public ProductEntity Product { get; set; }

        public void UpdateQuantity(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
