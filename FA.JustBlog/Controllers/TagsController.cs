using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.UoW;
using FA.JustBlog.ViewModel.Posts;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
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

        public IActionResult Details(string name)
        {
            var tag = uoW.TagsRepository.GetAll().ToList().FirstOrDefault(x => x.UrlSlug.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (tag == null)
            {
                return NotFound();
            }
            var posts = uoW.PostsRepository.GetPostsByTag(tag.UrlSlug);          
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
}
