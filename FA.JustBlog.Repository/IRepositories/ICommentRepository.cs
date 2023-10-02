using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository.IRepositories
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        /// <summary>
        /// add new comment
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="commentName"></param>
        /// <param name="commentEmail"></param>
        /// <param name="commentTitle"></param>
        /// <param name="commentBody"></param>
        void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);
        
        /// <summary>
        /// get comment for a post by postId
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>list of comment</returns>
        IList<Comment> GetCommentsForPost(int postId);
        
        /// <summary>
        /// get comment for a post by post
        /// </summary>
        /// <param name="post"></param>
        /// <returns>list of comment</returns>
        IList<Comment> GetCommentsForPost(Posts post);
    }
}
