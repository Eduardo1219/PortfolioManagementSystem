using Domain.Product.Entity;

namespace Domain.Product.Service
{
    public interface IProductService
    {
        Task AddProductAsync(ProductEntity entity);
        Task UpdateProductAsync(ProductEntity Id);
        Task<ProductEntity> GetProductByIdAsync(Guid entity);
        Task<int> GetCountAsync(decimal? price, DateTime? dueDate, bool? active);
        Task<List<ProductEntity>> GetPagedAsync(int take, int skip, decimal? price, DateTime? dueDate, bool? active);
    }
}
