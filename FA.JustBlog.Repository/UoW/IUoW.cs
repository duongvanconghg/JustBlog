using FA.JustBlog.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository.UoW
{
    public interface IUoW
    {
        ICategoriesRepository CategoryRepository { get; }
        IPostsRepository PostsRepository { get; }

        ITagsRepository TagsRepository { get; }
        ICommentRepository CommentRepository { get; }
        void SaveChanges();
    }
}
