using Domain.Base.Entity;
using Domain.ProductWallet.Entity;
using Domain.User.Entity;
using Domain.WalletTransaction.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Wallet.Entity
{
    public class WalletEntity : BaseEntity
    {
        [Required]
        [Column(TypeName = "money")]
        public decimal Balance { get; set; } = 0;
        [Column(TypeName = "money")]
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

            return true;
        }

        public void UpdateBalanceAfterBuy(decimal totalValue)
        {
            this.Balance = this.Balance - totalValue;
            this.InvestedBalance = totalValue;
            this.LastChangeDate = DateTime.UtcNow.AddHours(-3);
        }

        public void UpdateInvestedBalance(decimal totalValue, OperationType operationType)
        {
            this.LastChangeDate = DateTime.UtcNow.AddHours(-3);
            if (operationType == OperationType.Buy)
            {
                this.InvestedBalance = this.InvestedBalance + totalValue;
                return;
            }
            this.InvestedBalance = this.InvestedBalance - totalValue;

            return;
        }

        public void UpdateBalance(decimal totalValue, ModificationType modificationType)
        {
            if (modificationType == ModificationType.Positive)
            {
                this.Balance = this.Balance + totalValue;
                return;
            }

            this.Balance = this.Balance - totalValue;
        }
    }
}
