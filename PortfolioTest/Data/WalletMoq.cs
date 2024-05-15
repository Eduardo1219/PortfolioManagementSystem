using Domain.Wallet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTest.Data
{
    public static class WalletMoq
    {
        public static WalletEntity MoqWallet()
        {
            return new WalletEntity
            {
                Id = Guid.Parse("56f90381-9c86-4b78-89af-4fedb8179e36"),
                Balance = 10,
                InvestedBalance = 10,
                LastChangeDate = DateTime.Now
            };
        }
    }
}
