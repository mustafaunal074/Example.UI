using Example.Core.DataAccess.Abstract;
using Example.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DataAccess.Abstract
{
    public interface ICategoryDal : IBaseRepository<Category>
    {
        Task<Category> GetWithAsNoTracking(int id);
        Task<IList<Category>> GetCategoriesByNames();
    }
}
