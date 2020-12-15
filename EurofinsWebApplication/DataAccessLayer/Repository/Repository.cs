using BusinessLayer.Repository;
using DataAccessLayer.Context;
using DataAccessLayer.DatabaseFactory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private DatabaseContext _databaseContext;

        protected IDatabaseFactory DatabaseFactory { get; set; }
        protected IDbSet<TEntity> DbSet { get; set; }

        protected DatabaseContext DatabaseContext
        {
            get { return _databaseContext ?? (_databaseContext = DatabaseFactory.GetDatabaseContext()); }
            set { _databaseContext = value; }
        }


        public Repository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;

            DbSet = DatabaseContext.Set<TEntity>();
        }


        public TEntity Add(TEntity entity)
        {
            return DbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.FirstOrDefault(where);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public TEntity Update(TEntity entity)
        {
            var t = DbSet.Attach(entity);
            DatabaseContext.Entry(entity).State = EntityState.Modified;

            return t;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(@where);
        }
    }
}
