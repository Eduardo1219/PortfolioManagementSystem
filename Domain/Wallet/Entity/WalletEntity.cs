using Domain.Base.Entity;
using Domain.ProductWallet.Entity;
using Domain.User.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Wallet.Entity
{
    public class WalletEntity : BaseEntity
    {
        [Required]
        public decimal Balance { get; set; } = 0;
        public decimal? InvestedBalance { get; set; }
        public DateTime? LastChangeDate { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public virtual List<ProductWalletEntity>? productWalletEntities { get; set; }


        public bool ValidateBalance(decimal totalValue)
        {
            if (totalValue > this.Balance)
                return false;

            this.Balance = this.Balance - totalValue;
            return true;
        }

        public void UpdateBalance(decimal totalValue)
        {
            this.Balance = this.Balance + totalValue;
        }
    }
}
