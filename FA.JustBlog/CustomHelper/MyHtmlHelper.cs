using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FA.JustBlog.CustomHelper
{
    public static class MyHtmlHelper
    {
        public static IHtmlContent CategoryLink(this IHtmlHelper htmlHelper, string name, string urlSlug)
        {
            var url = $"/Categories/{urlSlug}";
            var link = new TagBuilder("a");
            link.Attributes.Add("href", url);
            link.AddCssClass("nav-link px-lg-3 py-3 py-lg-4");
            link.InnerHtml.Append(name);
            return link;
        }
    }
}
