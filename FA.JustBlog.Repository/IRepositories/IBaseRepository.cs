using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// create
        /// </summary>
        /// <param name="entity"></param>
        void Create(TEntity entity);

        void CreateRange(TEntity entity);

        /// <summary>
        /// update 
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        void UpdateRange(TEntity entity);

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// get list
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(int id);
    }
}
