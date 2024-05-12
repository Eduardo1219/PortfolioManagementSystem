using Domain.Wallet.Entity;


namespace Domain.Wallet.Service
{
    public interface IWalletService
    {
        Task AddWalletAsync(Guid id);

        Task UpdateWalletAsync(WalletEntity entity);

        Task<WalletEntity> GetWalletByIdAsync(Guid id);
    }
}
