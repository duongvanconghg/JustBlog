using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Views.Components
{
    public class AboutCard : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
