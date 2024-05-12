using Domain.Base.Repository;
using Domain.ProductWallet.Entity;
using Domain.User.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProductWallet.Repository
{
    public interface IProductWalletRepository : IBaseRepository<ProductWalletEntity>
    {
    }
}
