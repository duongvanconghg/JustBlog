using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.UoW;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Views.Components
{
    public class Menu : ViewComponent
    {
        public readonly IUoW uoW;

        public Menu(IUoW uoW)
        {
            this.uoW = uoW;
        }

        public IViewComponentResult Invoke()
        {
            List<Categories> category = uoW.CategoryRepository.GetAll().ToList();
            return View(category);
        }
    }
}
