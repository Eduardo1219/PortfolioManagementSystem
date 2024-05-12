using Domain.MongoBase.Entity;
using Domain.MongoBase.Repository;
using Domain.WalletTransaction.Entity;


namespace Domain.WalletTransaction.Repository
{
    public interface IWalletTransactionRepository : IMongoRepository<WalletTransactionEntity>
    {
    }
}
