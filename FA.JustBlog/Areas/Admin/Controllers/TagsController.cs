using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.UoW;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagsController : Controller
    {
        private readonly IUoW uoW;

        public TagsController(IUoW uoW)
        {
            this.uoW = uoW;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllTags()
        {
            var tags = uoW.TagsRepository.GetAll();
            return View(tags);
        }

        public IActionResult Detail(int id)
        {
            var tag = uoW.TagsRepository.GetById(id);
            return View(tag);
        }

        public IActionResult Edit(int id)
        {
            Tags tag = uoW.TagsRepository.GetById(id);

            if (tag != null)
            {
                return View(tag);
            }
            else
            {
                return RedirectToAction(nameof(AllTags));
            }
        }

        [HttpPost]
        public IActionResult Edit(Tags editTag)
        {
            var tag = uoW.TagsRepository.GetById(editTag.Id);
            if (tag != null)
            {
                tag.Name = editTag.Name;
                tag.Description = editTag.Description;
                tag.UrlSlug = editTag.UrlSlug;
                tag.Count = editTag.Count;
                uoW.TagsRepository.Update(tag);
                uoW.SaveChanges();
            }

            return RedirectToAction(nameof(AllTags));
        }

        public IActionResult Delete(int id)
        {
            uoW.TagsRepository.Delete(id);
            uoW.SaveChanges();
            return RedirectToAction(nameof(AllTags));
        }

        public IActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNew(Tags tag)
        {
            uoW.TagsRepository.Create(tag);
            uoW.SaveChanges();
            return RedirectToAction(nameof(AllTags));
        }
    }
}
