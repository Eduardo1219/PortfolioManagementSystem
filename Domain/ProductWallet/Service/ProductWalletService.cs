using Domain.Product.Entity;
using Domain.ProductWallet.Entity;
using Domain.ProductWallet.Repository;
using Domain.Wallet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProductWallet.Service
{
    public class ProductWalletService : IProductWalletService
    {
        private IProductWalletRepository _repository;

        public ProductWalletService(IProductWalletRepository repository)
        {
            _repository = repository;
        }

        public async Task BuyProduct(WalletEntity walletEntity, ProductEntity productEntity, int quantity)
        {
            var productWallet = await GetProductWallet(walletEntity.Id, productEntity.Id);

            if (productWallet == null)
            {
                await AddProductToWallet(walletEntity, productEntity, quantity);
                return;
            }

            await UpdateProductWallet(productWallet, quantity);
        }

        public async Task<ProductWalletEntity> GetById(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddProductToWallet(WalletEntity walletEntity, ProductEntity productEntity, int quantity)
        {

            var entity = new ProductWalletEntity
            {
                ProductValueAtPurchase = productEntity.Price,
                ProductPurchaseDate = DateTime.Now,
                Quantity = quantity,
                WalletId = walletEntity.Id,
                ProductId = productEntity.Id
            };

            try
            {
                await _repository.AddAsync(entity);
            }
            catch(Exception ex) { }
            
        }

        public async Task<ProductWalletEntity> GetProductWallet(Guid walletId, Guid productId)
        {
            var productWallet = await _repository.GetFirstAsync(p => p.WalletId == walletId && p.ProductId == productId);

            return productWallet;
        }

        public async Task<List<ProductWalletEntity>> GetProductByWalletId(Guid walletId)
        {
            var productWallet = await _repository.GetAsync(p => p.WalletId == walletId, p => p.ProductPurchaseDate);

            return productWallet.ToList();
        }

        public async Task UpdateProductWallet(ProductWalletEntity entity, int quantity)
        {
            entity.UpdateQuantity(quantity);
            if (quantity > 0)
            {
                await _repository.UpdateAsync(entity);
                return;
            }

            await _repository.RemoveAsync(entity);
        }
    }
}
