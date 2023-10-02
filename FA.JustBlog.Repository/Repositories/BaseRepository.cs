using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly JustBlogContext _context;
        protected DbSet<TEntity> _entities;

        public BaseRepository(JustBlogContext? context = null)
        {
            _context = context ?? new JustBlogContext();
            _entities = _context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void CreateRange(TEntity entity)
        {
            _entities.AddRange(entity);
        }

        public void Delete(int id)
        {
            _entities.Remove(_entities.Find(id));
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }

        public TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public void UpdateRange(TEntity entity)
        {
            _entities.UpdateRange(entity);
        }
    }
}
