using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(JustBlogContext? context = null) : base(context)
        {

        }

        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var newComment = new Comment();
            newComment.PostId = postId;
            newComment.Name = commentName;
            newComment.Email = commentEmail;
            newComment.CommentHeader = commentTitle;
            newComment.CommentText = commentBody;
            _context.Add(newComment);
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            var post = _context.Posts.ToList().FirstOrDefault(x => x.Id == postId);
            if (post == null)
            {
                return null;
            } else
            {
                List <Comment> comments = _context.Comment.ToList().Where(x => x.PostId == postId).ToList();
                return comments;
            }
        }

        public IList<Comment> GetCommentsForPost(Posts post)
        {
            var contain = _context.Posts.ToList().Contains(post);
            if (contain == false)
            {
                return null;
            }
            else
            {
                List<Comment> comments = _context.Comment.ToList().Where(x => x.PostId == post.Id).ToList();
                return comments;
            }
        }
    }
}
