using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Repository.IRepositories;
using FA.JustBlog.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository.UoW
{
    public class UoW : IUoW, IDisposable
    {
        private readonly JustBlogContext context;
        private ICategoriesRepository categoriesRepository;
        private IPostsRepository postsRepository;
        private ITagsRepository tagsRepository;
        private ICommentRepository commentRepository;
        private bool disposed = false;

        public UoW(JustBlogContext context = null)
        {
            this.context = context ?? new JustBlogContext();
        }

        public ICategoriesRepository CategoryRepository => categoriesRepository ?? new CategoriesRepository(context);

        public IPostsRepository PostsRepository => postsRepository ?? new PostsRepository(context);

        public ITagsRepository TagsRepository => tagsRepository ?? new TagsRepository(context);
        public ICommentRepository CommentRepository => commentRepository ?? new CommentRepository(context);
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
