using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository.Repositories
{
    public class TagsRepository : BaseRepository<Tags>, ITagsRepository
    {
        public TagsRepository(JustBlogContext? context = null) : base(context)
        {

        }

        public IList<Tags> GetTagsByPost(string post)
        {
            var curPost = _context.Posts.FirstOrDefault(x => EF.Functions.Like(x.UrlSlug, $"%{post}%"));
            if (curPost != null)
            {
                List<PostTagMap> lists = _context.PostTagMap.Where(x => x.PostId == curPost.Id).ToList();
                List<Tags> tags = new List<Tags>();
                foreach (var list in lists)
                {
                    var id = list.TagId;
                    var newTag = _context.Tags.FirstOrDefault(x => x.Id == id);
                    if (newTag != null)
                    {
                        tags.Add(newTag);
                    }
                }
                return tags;
            }

            return null;
        }
    }
}
