using Example.Core.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Core.DataAccess.Concrete.EntityFramework
{
    public class EfUnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : DbContext, new()
    {
        private readonly TContext _context;
        public EfUnitOfWork(TContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
