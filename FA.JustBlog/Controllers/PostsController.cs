using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.UoW;
using FA.JustBlog.ViewModel.Posts;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
    public class PostsController : Controller
    {

        private readonly IUoW uoW;

        public PostsController(IUoW uoW)
        {
            this.uoW = uoW;
        }

        public IActionResult Index()
        {
            var posts = uoW.PostsRepository.GetPublishedPosts().ToList();
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
                postVM.Comments = uoW.CommentRepository.GetCommentsForPost(post.Id);
                postsVMs.Add(postVM);
            }
            ViewBag.Posts = postsVMs;
            return View();
        }

        public IActionResult Detail(int id)
        {
            Posts post = uoW.PostsRepository.GetById(id);
            return View(post);
        }

        public IActionResult Details(int year, int month, string title)
        {
            var post = uoW.PostsRepository.FindPost(year, month, title);
            if (post == null)
            {
                return RedirectToAction("Index");
            }
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
            postVM.Comments = uoW.CommentRepository.GetCommentsForPost(post.Id);
            return View(postVM);
        }
    }
}
