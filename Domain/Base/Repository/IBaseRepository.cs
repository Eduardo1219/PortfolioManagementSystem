using Domain.Base.Entity;
using System.Linq.Expressions;

namespace Domain.Base.Repository
{
    public interface IBaseRepository<TB> where TB : BaseEntity
    {
        Task AddAsync(TB entity);

        Task RemoveAsync(TB entity);

        Task RemoveByIdAsync(Guid id);

        Task UpdateAsync(TB entity);

        Task<TB> GetByIdAsync(Guid id);

        Task<IList<TB>> GetPagedAsync(Expression<Func<TB, bool>> search, int take, int skip, Expression<Func<TB, dynamic>> orderDesc);

        Task<IList<TB>> GetAsync(Expression<Func<TB, bool>> search, Expression<Func<TB, dynamic>> orderDesc);

        Task<IList<TB>> GetAsync(Expression<Func<TB, bool>> search);

        Task<TB> GetFirstAsync(Expression<Func<TB, bool>> search);
    }
}
