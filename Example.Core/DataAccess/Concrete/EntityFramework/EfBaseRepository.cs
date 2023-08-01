using Example.Core.DataAccess.Abstract;
using Example.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Example.Core.DataAccess.Concrete.EntityFramework
{
    public class EfBaseRepository<TContext, TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        private readonly TContext _context;
        public EfBaseRepository(TContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(TEntity Model)
        {
            //_context.Entry<TEntity>(Model).State = EntityState.Added;
            await _context.Set<TEntity>().AddAsync(Model);
            return true;
        }

        public async Task<bool> Delete(TEntity Model)
        {
            _context.Entry<TEntity>(Model).State = EntityState.Deleted;
            //_context.Set<TEntity>().Remove(Model);
            return true;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<IList<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? await _context.Set<TEntity>().ToListAsync() : await _context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<bool> Update(TEntity Model)
        {
            _context.Entry<TEntity>(Model).State = EntityState.Modified;
            //_context.Set<TEntity>().Update(Model);
            return true;
        }
    }
}
