using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.UoW;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
    public class CommentController : Controller
    {
        private readonly IUoW uoW;

        public CommentController(IUoW uoW)
        {
            this.uoW = uoW;
        }
        
        [HttpPost("Comment/Add")]
        public IActionResult CreateNew(string postId, string header, string text, string name, string email)
        {
            int id = 0;
            bool check = int.TryParse(postId, out id);
            if (id != 0)
            {
                uoW.CommentRepository.AddComment(id, name, email, header, text);
            }
            uoW.SaveChanges();
            return Json(new { Name = name, CommentText = text });
        }
    }
}
