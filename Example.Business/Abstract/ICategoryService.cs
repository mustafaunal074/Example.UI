using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Entities.Models;

namespace Example.Business.Abstract
{
    public interface ICategoryService
    {
        Task<bool> AddCategory(Category category);
        Task<bool> UpdateCategory(Category category);
        Task<bool> UpdateCategories(List<Category> categories);
        Task<bool> DeleteCategory(int id);
        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByName(string name);
        Task<IList<Category>> GetCategoryList();
    }
}
