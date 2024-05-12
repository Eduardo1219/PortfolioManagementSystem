using Domain.Product.Entity;
using PortfolioManagementSystem.Controllers.Product.Dto;

namespace PortfolioManagementSystem.Helpers.Mappers
{
    public static class ProductMapper
    {
        public static ProductEntity MapProductEntity(this ProductDto NewProductDto)
        {
            ProductEntity productEntity = new ProductEntity
            {
                Active = NewProductDto.Active,
                Description = NewProductDto.Description,
                DueDate = NewProductDto.DueDate,
                Price = NewProductDto.Price,
            };

            return productEntity;
        }

        public static ProductEntity MapUpdateEntity(ProductEntity productEntity, ProductDto dto)
        {
            ProductEntity entity = new ProductEntity
            {
                AddedDate = productEntity.AddedDate,
                Active = dto.Active,
                Description = dto.Description,
                DueDate = dto.DueDate,
                Price = dto.Price,
                Id = productEntity.Id,
                LastChangeDate = DateTime.UtcNow.AddDays(-3)
            };

            return entity;
        }
    }
}
