using Domain.Product.Entity;
using Domain.Product.Repository;

namespace Domain.Product.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }


        public async Task AddProductAsync(ProductEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateProductAsync(ProductEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task<ProductEntity> GetProductByIdAsync(Guid Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<int> GetCountAsync(decimal? price, DateTime? dueDate, bool? active)
        {
            return await _repository.GetCountAsync(p => 
            price.HasValue ? price.Value == p.Price : true &&
            (dueDate.HasValue ? p.DueDate <= dueDate.Value : true) &&
            (active.HasValue ? p.Active == active.Value : true));
        }


        public async Task<List<ProductEntity>> GetPagedAsync(int take, int skip, decimal? price, DateTime? dueDate, bool? active)
        {
            var products = await _repository.GetPagedAsync(p =>
            price.HasValue ? price.Value == p.Price : true &&
            (dueDate.HasValue ? p.DueDate <= dueDate.Value : true) &&
            (active.HasValue ? p.Active == active.Value : true), 
            take, 
            skip, 
            p => p.DueDate);

            return products.ToList();
        }
    }
}
