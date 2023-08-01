using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Business.Abstract;
using Example.Business.ValidationRules.FluentValidation;
using Example.Core.DataAccess.Abstract;
using Example.DataAccess.Abstract;
using Example.DataAccess.Concrete.EntityFramework.Context;
using Example.Entities.Models;
using FluentValidation;

namespace Example.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        public CategoryManager(ICategoryDal categoryDal, IUnitOfWork<AppDbContext> unitOfWork)
        {
            _categoryDal = categoryDal;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddCategory(Category category)
        {
            try
            {
                CategoryValidator validations = new CategoryValidator();
                var validationResult = validations.Validate(category);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }

                if (await GetCategoryByName(category.Name) == null)
                {
                    await _categoryDal.Add(category);
                    await _unitOfWork.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //Error sayfasına yönlendirme
                return false;
            }
        }

        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                var category = await GetCategoryById(id);
                if (category != null)
                {
                    await _categoryDal.Delete(category);
                    await _unitOfWork.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //Error sayfasına yönlendirme
                return false;
            }
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _categoryDal.Get(x => x.Id == id);
            if (category == null)
            {
                return null;
            }
            return category;
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            //var categories = await _categoryDal.GetCategoriesByNames();
            var category = await _categoryDal.Get(x => x.Name.Contains(name));
            if (category == null)
            {
                return null;
            }
            return category;
        }

        public async Task<IList<Category>> GetCategoryList()
        {
            var categoryList = await _categoryDal.GetList();
            if (categoryList.Count == 0)
            {
                return null;
            }
            return categoryList;
        }

        public Task<bool> UpdateCategories(List<Category> categories)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            try
            {
                CategoryValidator validations = new CategoryValidator();
                var validationResult = validations.Validate(category);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }

                var findCategory = await _categoryDal.GetWithAsNoTracking(category.Id);

                if (findCategory != null)
                {
                    findCategory.Name = category.Name;
                    findCategory.Description = category.Description;

                    await _categoryDal.Update(findCategory);
                    await _unitOfWork.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //Error sayfasına yönlendirme
                return false;
            }
        }
    }
}
