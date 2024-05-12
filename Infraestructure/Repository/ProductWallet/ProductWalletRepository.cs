using Domain.ProductWallet.Entity;
using Domain.ProductWallet.Repository;
using Domain.Wallet.Entity;
using Domain.Wallet.Repository;
using Infraestructure.Context;
using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.ProductWallet
{
    public class ProductWalletRepository : BaseRepository<ProductWalletEntity>, IProductWalletRepository
    {
        private readonly PortfolioManagementContext _context;

        public ProductWalletRepository(PortfolioManagementContext context) : base(context)
        {
            _context = context;
        }
    }
}
