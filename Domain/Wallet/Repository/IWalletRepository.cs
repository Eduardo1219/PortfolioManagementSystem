using Domain.Base.Repository;
using Domain.User.Entity;
using Domain.Wallet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Wallet.Repository
{
    public interface IWalletRepository : IBaseRepository<WalletEntity>
    {
    }
}
