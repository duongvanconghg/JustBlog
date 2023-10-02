using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.UoW;
using FA.JustBlog.ViewModel.Posts;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IUoW uoW;

        public CategoriesController(IUoW uoW)
        {
            this.uoW = uoW;
        }

        public IActionResult Index()
        {
            var categories = uoW.CategoryRepository.GetAll().ToList();
            ViewBag.Categories = categories;
            return View();
        }

        
        public IActionResult Details(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Categories category = uoW.CategoryRepository.GetAll().ToList().Where(x => x.UrlSlug.Contains(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (category != null)
                {
                    List<Posts> posts = uoW.PostsRepository.GetPostsByCategory(category.Name).ToList();
                    var categories = uoW.CategoryRepository.GetAll().ToList();
                    ViewBag.Categories = categories;
                    List<PostsVM> postsVMs = new List<PostsVM>();
                    foreach (var post in posts)
                    {
                        PostsVM postVM = new PostsVM();
                        postVM.Id = post.Id;
                        postVM.Title = post.Title;
                        postVM.ShortDescription = post.ShortDescription;
                        postVM.Published = post.Published;
                        postVM.UrlSlug = post.UrlSlug;
                        postVM.PostedOn = post.PostedOn;
                        postVM.PostContent = post.PostContent;
                        postVM.Modified = post.Modified;
                        postVM.CategoryId = post.CategoryId;
                        postVM.Tags = uoW.TagsRepository.GetTagsByPost(post.UrlSlug);
                        postsVMs.Add(postVM);
                    }
                    ViewBag.Posts = postsVMs;
                    return View();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
