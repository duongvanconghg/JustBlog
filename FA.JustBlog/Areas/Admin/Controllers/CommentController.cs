using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.UoW;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly IUoW uoW;

        public CommentController(IUoW uoW)
        {
            this.uoW = uoW;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllComments()
        {
            var comments = uoW.CommentRepository.GetAll();
            return View(comments);
        }

        public IActionResult Detail(int id)
        {
            var comment = uoW.CommentRepository.GetById(id);
            return View(comment);
        }

        public IActionResult Edit(int id)
        {
            Comment comment = uoW.CommentRepository.GetById(id);

            if (comment != null)
            {
                return View(comment);
            }
            else
            {
                return RedirectToAction(nameof(AllComments));
            }
        }

        [HttpPost]
        public IActionResult Edit(Comment editComment)
        {
            var comment = uoW.CommentRepository.GetById(editComment.Id);
            if (comment != null)
            {
                comment.Name = editComment.Name;
                comment.Email = editComment.Email;
                comment.CommentHeader = editComment.CommentHeader;
                comment.CommentText = editComment.CommentText;
                uoW.CommentRepository.Update(comment);
                uoW.SaveChanges();
            }

            return RedirectToAction(nameof(AllComments));
        }

        public IActionResult Delete(int id)
        {
            uoW.CommentRepository.Delete(id);
            uoW.SaveChanges();
            return RedirectToAction(nameof(AllComments));
        }

        public IActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNew(Comment comment)
        {
            uoW.CommentRepository.Create(comment);
            uoW.SaveChanges();
            return RedirectToAction(nameof(AllComments));
        }
    }
}
