using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository.Repositories
{
    public class PostsRepository : BaseRepository<Posts>, IPostsRepository
    {
        public PostsRepository(JustBlogContext context) : base(context) { }


        public int CountPostsForCategory(string categoryName)
        {
            Categories category = _context.Categories.ToList().FirstOrDefault(x => x.Name.Contains(categoryName, StringComparison.OrdinalIgnoreCase));
            if (category == null)
            {
                return 0;
            }
            
            return _context.Posts.ToList().Where(x => x.CategoryId == category.Id).ToList().Count();
        }

        public Posts FindPost(int year, int month, string urlSlug)
        {
            return _context.Posts.ToList().FirstOrDefault(x => x.PostedOn.Year == year && x.PostedOn.Month == month && x.UrlSlug == urlSlug);
        }

        public IList<Posts> GetLastestPost(int size)
        {
            if (size < 0 || size > _context.Posts.Count())
            {
                return null;
            }
            else
            {
                List<Posts> posts = _context.Posts.ToList().OrderByDescending(x => x.PostedOn).ToList();
                List<Posts> lastestPosts = new List<Posts>();
                int i = 0;
                while (lastestPosts.Count() < size && i < posts.Count)
                {
                    if (posts[i].Published != false)
                    {
                        lastestPosts.Add(posts[i]);
                    }
                    i++;
                }

                return lastestPosts;
            }
        }

        public IList<Posts> GetPostsByCategory(string categoryName)
        {
            Categories category = _context.Categories.ToList().FirstOrDefault(x => x.Name.Contains(categoryName, StringComparison.OrdinalIgnoreCase));
            if (category == null)
            {
                return null;
            }
            List<Posts> posts = _context.Posts.ToList().Where(x => x.CategoryId == category.Id).ToList();
            List<Posts> postsByCategory = new List<Posts>();
            foreach (var post in posts)
            {
                if (post.Published != false)
                {
                    postsByCategory.Add(post);
                }
            }
            return postsByCategory;
        }

        public IList<Posts> GetPostsByMonth(DateTime monthYear)
        {
            return _context.Posts.Where(x => x.PostedOn.Month == monthYear.Month).ToList();
        }

        public IList<Posts> GetPublishedPosts()
        {
            return _context.Posts.Where(x => x.Published == true).ToList();
        }

        public IList<Posts> GetUnpublishedPosts()
        {
            return _context.Posts.Where(x => x.Published == false).ToList();
        }

        public int CountPostsForTag(string tag)
        {
            var curTag = _context.Tags.FirstOrDefault(x => x.Name.Contains(tag, StringComparison.OrdinalIgnoreCase));
            if (curTag != null)
            {
                List<PostTagMap> list = _context.PostTagMap.Where(x => x.TagId == curTag.Id).ToList();
                return list.Count();
            }

            return 0;
        }

        public IList<Posts> GetPostsByTag(string tag)
        {
            var curTag = _context.Tags.FirstOrDefault(x => EF.Functions.Like(x.UrlSlug, $"%{tag}%"));
            if (curTag != null)
            {
                List<PostTagMap> lists = _context.PostTagMap.Where(x => x.TagId == curTag.Id).ToList();
                List<Posts> posts = new List<Posts>();
                foreach (var list in lists)
                {
                    var id = list.PostId;
                    var newPost = _context.Posts.FirstOrDefault(x => x.Id == id);
                    if (newPost != null)
                    {
                        posts.Add(newPost);
                    }
                }
                return posts;
            }

            return null;
        }
    }
}
