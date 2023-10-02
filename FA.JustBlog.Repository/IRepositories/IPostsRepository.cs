using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository.IRepositories
{
    public interface IPostsRepository : IBaseRepository<Posts>
    {
        /// <summary>
        /// find post by year month and url slug
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="urlSlug"></param>
        /// <returns>fist post of list post</returns>
        Posts FindPost(int year, int month, string urlSlug);

        /// <summary>
        /// get published posts
        /// </summary>
        /// <returns>a list of published posts</returns>
        IList<Posts> GetPublishedPosts();

        /// <summary>
        /// get unpublished posts
        /// </summary>
        /// <returns>a list of unpublished posts</returns>
        IList<Posts> GetUnpublishedPosts();

        /// <summary>
        /// get lastest posts
        /// </summary>
        /// <param name="size"></param>
        /// <returns>a list of lastest posts</returns>
        IList<Posts> GetLastestPost(int size);

        /// <summary>
        /// get posts by month
        /// </summary>
        /// <param name="monthYear"></param>
        /// <returns>a list of posts posted on that month</returns>
        IList<Posts> GetPostsByMonth(DateTime monthYear);
        
        /// <summary>
        /// count how many posts a category has
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns>an integer</returns>
        int CountPostsForCategory(string categoryName);

        /// <summary>
        /// get a list of posts of a category
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns>a list</returns>
        IList<Posts> GetPostsByCategory(string categoryName);

        /// <summary>
        /// get a list of posts by tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>a list</returns>
        IList<Posts> GetPostsByTag(string tag);

    }
}
