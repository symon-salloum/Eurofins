using System;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLayer.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);

        IQueryable<TEntity> GetAll();

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
