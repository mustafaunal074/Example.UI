using Example.Core.DataAccess.Concrete.EntityFramework;
using Example.DataAccess.Abstract;
using Example.DataAccess.Concrete.EntityFramework.Context;
using Example.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfBaseRepository<AppDbContext, Category>, ICategoryDal
    {
        private readonly AppDbContext _context;
        public EfCategoryDal(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Category> GetWithAsNoTracking(int id)
        {
            return await _context.Category.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IList<Category>> GetCategoriesByNames()
        {
            return null;
        }
    }
}
