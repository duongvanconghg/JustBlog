using FA.JustBlog.Core.Models;
using FA.JustBlog.Models;
using FA.JustBlog.Repository.UoW;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FA.JustBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUoW uoW;

        public HomeController(ILogger<HomeController> logger, IUoW uoW)
        {
            _logger = logger;
            this.uoW = uoW;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}