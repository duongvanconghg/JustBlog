using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.UoW;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Views.Components
{
    public class LastestPosts : ViewComponent
    {
        public readonly IUoW uoW;

        public LastestPosts(IUoW uoW)
        {
            this.uoW = uoW;
        }

        public IViewComponentResult Invoke()
        {
            List<Posts> posts = uoW.PostsRepository.GetLastestPost(5).ToList();
            return View(posts);
        }
    }
}
