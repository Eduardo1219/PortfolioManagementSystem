using Domain.Base.Repository;
using Domain.Product.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Product.Repository
{
    public interface IProductRepository : IBaseRepository<ProductEntity>
    {

    }
}
