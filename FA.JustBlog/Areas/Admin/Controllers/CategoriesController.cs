using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.UoW;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IUoW uoW;

        public CategoriesController(IUoW uoW)
        {
            this.uoW = uoW;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllCategories()
        {
            List<Categories> categories = uoW.CategoryRepository.GetAll().ToList();
            return View(categories);
        }

        public IActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNew(Categories category)
        {           
            uoW.CategoryRepository.Create(category);
            uoW.SaveChanges();
            return RedirectToAction(nameof(AllCategories));
        }

        public IActionResult Detail(int id)
        {
            Categories category = uoW.CategoryRepository.GetById(id);
            return View(category);

        }

        public IActionResult Delete(int id)
        {
            uoW.CategoryRepository.Delete(id);
            uoW.SaveChanges();
            return RedirectToAction(nameof(AllCategories));
        }

        public IActionResult Edit(int id)
        {
            Categories category = uoW.CategoryRepository.GetById(id);
            
            if (category != null)
            {
                return View(category);
            }
            else
            {
                return RedirectToAction(nameof(AllCategories));
            }
        }

        [HttpPost]
        public IActionResult Edit(Categories editCategory)
        {
            var category = uoW.CategoryRepository.GetById(editCategory.Id);
            if (category != null)
            {
                category.Name = editCategory.Name;
                category.Description = editCategory.Description;              
                category.UrlSlug = editCategory.UrlSlug;             
                uoW.CategoryRepository.Update(category);
                uoW.SaveChanges();
            }

            return RedirectToAction(nameof(AllCategories));
        }
    }
}
