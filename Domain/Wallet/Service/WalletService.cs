using Domain.Wallet.Entity;
using Domain.Wallet.Repository;


namespace Domain.Wallet.Service
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _repository;

        public WalletService(IWalletRepository repository)
        {
            _repository = repository;
        }

        public async Task AddWalletAsync(Guid userId)
        {
            var walletEntity = new WalletEntity
            {
                Balance = 0,
                UserId = userId,
            };

            await _repository.AddAsync(walletEntity);
        }

        public async Task UpdateWalletAsync(WalletEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task<WalletEntity> GetWalletByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<WalletEntity> GetWalletByUserIdAsync(Guid id)
        {
            var wallet = await _repository.GetFirstAsync(w => w.UserId == id);
            return wallet;
        }

        //public async Task<int> GetCountAsync(string? search, string? email, bool? active, WalletEnum? permission)
        //{
        //    return await _repository.GetCountAsync(p =>
        //    !string.IsNullOrEmpty(search) ? (p.Name.Contains(search) || p.LastName.Contains(search)) : true &&
        //    (!string.IsNullOrEmpty(email) ? p.Email.Contains(email) : true) &&
        //    (permission.HasValue ? p.Permission == permission.Value : true) &&
        //    (active.HasValue ? p.Active == active.Value : true));
        //}


        //public async Task<List<WalletEntity>> GetPagedAsync(int take, int skip, string? search, string? email, bool? active, WalletEnum? permission)
        //{
        //    var products = await _repository.GetPagedAscAsync(p =>
        //    !string.IsNullOrEmpty(search) ? (p.Name.Contains(search) || p.LastName.Contains(search)) : true &&
        //    (!string.IsNullOrEmpty(email) ? p.Email.Contains(email) : true) &&
        //    (permission.HasValue ? p.Permission == permission.Value : true) &&
        //    (active.HasValue ? p.Active == active.Value : true),
        //    take,
        //    skip,
        //    p => p.Name);

        //    return products.ToList();
        //}
    }
}
