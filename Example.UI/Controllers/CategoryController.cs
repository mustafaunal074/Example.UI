using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Business.Abstract;
using Example.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example.UI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoryList();
            if (categories == null)
            {
                //Error sayfasına git.
            }
            return View(categories);
        }
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                //Error sayfasına yönlendirme
            }
            return View(category);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                //error sayfasına yönlendirme
            }
            bool result = await _categoryService.AddCategory(category);
            if (!result)
            {
                //error sayfasına yönlendirme
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                //Error sayfasına yönlendirme
            }
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                //error sayfasına yönlendirme
            }
            bool result = await _categoryService.UpdateCategory(category);
            if (!result)
            {
                //error sayfasına yönlendirme
            }
            return RedirectToAction("Index");
        }
    }
}
