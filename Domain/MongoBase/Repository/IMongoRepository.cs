using Domain.MongoBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MongoBase.Repository
{
    public interface IMongoRepository<TB> where TB : BaseMongoEntity
    {
        Task AddAsync(TB entity);

        Task RemoveAsync(TB entity);

        Task RemoveByIdAsync(Guid id);

        Task UpdateAsync(TB entity);

        Task<List<TB>> GetAsync(Expression<Func<TB, bool>> search);

        Task<TB> GetByIdAsync(Guid id);
    }
}
