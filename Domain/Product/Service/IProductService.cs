using Domain.Product.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
