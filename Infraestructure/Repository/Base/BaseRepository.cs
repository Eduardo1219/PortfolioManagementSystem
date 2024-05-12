using Domain.Base.Entity;
using Domain.Base.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Base
{
    public abstract class BaseRepository<B> : IBaseRepository<B> where B : BaseEntity
    {
        private readonly DbContext _context;

        protected BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task AddAsync(B entity)
        {
            var dbSet = _context.Set<B>();
            dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<B> GetByIdAsync(Guid id)
        {
            var dbSet = _context.Set<B>();
            var entity = await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }


        public virtual async Task RemoveAsync(B entity)
        {
            var dbSet = _context.Set<B>();
            dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoveByIdAsync(Guid id)
        {
            var dbSet = _context.Set<B>();
            var entity = await dbSet.FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
                return;

            dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(B entity)
        {
            var dbSet = _context.Set<B>();
            dbSet.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<IList<B>> GetPagedAsync(Expression<Func<B, bool>> search, int take, int skip, Expression<Func<B, dynamic>> orderDesc)
        {
            return await _context.Set<B>()
                .AsNoTracking()
                .Where(search)
                .OrderByDescending(orderDesc)
                .Skip(skip == 0 ? 0 : (skip - 1) * take)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IList<B>> GetPagedAscAsync(Expression<Func<B, bool>> search, int take, int skip, Expression<Func<B, dynamic>> order)
        {
            return await _context.Set<B>()
                .AsNoTracking()
                .Where(search)
                .OrderBy(order)
                .Skip(skip == 0 ? 0 : (skip - 1) * take)
                .Take(take)
                .ToListAsync();
        }

        public async Task<int> GetCountAsync(Expression<Func<B, bool>> search)
        {
            return await _context.Set<B>()
                .AsNoTracking()
                .Where(search).CountAsync();
        }

        public async Task<IList<B>> GetAsync(Expression<Func<B, bool>> search, Expression<Func<B, dynamic>> orderDesc)
        {
            return await _context.Set<B>()
                .AsNoTracking()
                .Where(search)
                .OrderByDescending(orderDesc)
                .ToListAsync();
        }

        public async Task<IList<B>> GetAsync(Expression<Func<B, bool>> search)
        {
            return await _context.Set<B>()
                .AsNoTracking()
                .Where(search)
                .ToListAsync();
        }

        public async Task<B> GetFirstAsync(Expression<Func<B, bool>> search)
        {
            return await _context.Set<B>()
                .AsNoTracking()
                .FirstOrDefaultAsync(search);
        }
    }
}
