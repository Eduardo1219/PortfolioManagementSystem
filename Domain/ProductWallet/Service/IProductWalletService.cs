using Domain.Product.Entity;
using Domain.ProductWallet.Entity;
using Domain.Wallet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProductWallet.Service
{
    public interface IProductWalletService
    {
        Task AddProductToWallet(WalletEntity walletEntity, ProductEntity productEntity, int quantity);
        Task<ProductWalletEntity> GetProductWallet(Guid walletId, Guid productId);
        Task<List<ProductWalletEntity>> GetProductByWalletId(Guid walletId);
        Task UpdateProductWallet(ProductWalletEntity entity, int quantity);
        Task BuyProduct(WalletEntity walletEntity, ProductEntity productEntity, int quantity);
        Task<ProductWalletEntity> GetById(Guid id);
    }
}
