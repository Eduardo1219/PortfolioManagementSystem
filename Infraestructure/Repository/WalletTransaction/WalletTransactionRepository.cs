using Domain.MongoBase.Entity;
using Domain.MongoBase.Repository;
using Domain.MongoBase.Settings;
using Domain.User.Entity;
using Domain.User.Repository;
using Domain.WalletTransaction.Entity;
using Domain.WalletTransaction.Repository;
using Infraestructure.Repository.Base;
using Infraestructure.Repository.BaseMongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.WalletTransaction
{
    public class WalletTransactionRepository : MongoRepository<WalletTransactionEntity>, IWalletTransactionRepository
    {
        private readonly IDatabaseSettings _settings;
        public WalletTransactionRepository(IDatabaseSettings settings) : base(settings)
        {
            _settings = settings;
        }
    }
}
