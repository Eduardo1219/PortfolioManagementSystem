using Domain.Product.Entity;
using Domain.Product.Repository;
using Infraestructure.Context;
using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Product
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        private readonly PortfolioManagementContext _context;

        public ProductRepository(PortfolioManagementContext context) : base(context)
        {
            _context = context;
        }
    }
}
