using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository.IRepositories
{
    public interface ITagsRepository : IBaseRepository<Tags>
    {
        /// <summary>
        /// Get tags list by post
        /// </summary>
        /// <param name="post"></param>
        /// <returns>a list of tags</returns>
        IList<Tags> GetTagsByPost(string post);
    }
}
