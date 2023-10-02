using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.UoW;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {
        private readonly IUoW uoW;

        public PostsController(IUoW uoW)
        {
            this.uoW = uoW;
        }

        public IActionResult AllPosts()
        {
            List<Posts> Posts = uoW.PostsRepository.GetAll().ToList();
            return View(Posts);
        }
        public IActionResult LastestPosts()
        {
            List<Posts> lastestPosts = uoW.PostsRepository.GetAll().ToList().OrderByDescending(x => x.PostedOn).ToList();
            return View(lastestPosts);
        }

        public IActionResult PublishedPosts()
        {

            List<Posts> publishedPosts = uoW.PostsRepository.GetPublishedPosts().ToList();
            return View(publishedPosts);
        }

        public IActionResult UnPublishedPosts()
        {

            List<Posts> unPublishedPosts = uoW.PostsRepository.GetUnpublishedPosts().ToList();
            return View(unPublishedPosts);
        }

        public IActionResult CreateNew()
        {
            var categories = uoW.CategoryRepository.GetAll().ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult CreateNew(Posts post)
        {
            post.Modified = DateTime.Now;
            uoW.PostsRepository.Create(post);
            uoW.SaveChanges();
            return RedirectToAction(nameof(AllPosts));
        }

        public IActionResult Detail(int id)
        {          
            Posts post = uoW.PostsRepository.GetById(id);
            return View(post);
            
        }

        public IActionResult Delete(int id)
        {           
            uoW.PostsRepository.Delete(id);
            uoW.SaveChanges();
            return RedirectToAction(nameof(AllPosts));   
        }

        public IActionResult Edit(int id)
        {
            Posts post = uoW.PostsRepository.GetById(id);
            var categories = uoW.CategoryRepository.GetAll().ToList();
            ViewBag.Categories = categories;
            var categoryName = categories.FirstOrDefault(x => x.Id == post.CategoryId).Name;
            ViewBag.CategoryName = categoryName;
            if (post != null)
            {
                return View(post);
            } else
            {
                return RedirectToAction(nameof(AllPosts));
            }
        }

        [HttpPost]
        public IActionResult Edit(Posts editPost)
        {
            var post = uoW.PostsRepository.GetById(editPost.Id);
            if (post != null)
            {
                post.Title = editPost.Title;
                post.ShortDescription = editPost.ShortDescription;
                post.PostContent = editPost.PostContent;
                post.CategoryId = editPost.CategoryId;
                post.PostedOn = editPost.PostedOn;
                post.Modified = DateTime.Now;
                post.UrlSlug = editPost.UrlSlug;
                post.Published = editPost.Published;
                uoW.PostsRepository.Update(post);
                uoW.SaveChanges();
            }
            
            return RedirectToAction(nameof(AllPosts));
        }
    }
}
