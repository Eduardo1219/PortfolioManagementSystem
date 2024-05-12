using Domain.Wallet.Entity;
using Domain.Wallet.Repository;
using Infraestructure.Context;
using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Wallet
{
    public class WalletRepository : BaseRepository<WalletEntity>, IWalletRepository
    {
        private readonly PortfolioManagementContext _context;

        public WalletRepository(PortfolioManagementContext context) : base(context)
        {
            _context = context;
        }
    }
}
