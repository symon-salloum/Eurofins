using BusinessLayer.UnitOfWork;
using DataAccessLayer.Context;
using DataAccessLayer.DatabaseFactory;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private DatabaseContext _databaseContext;

        protected DatabaseContext DataContext => _databaseContext ?? (_databaseContext = _databaseFactory.GetDatabaseContext());

        public void Commit()
        {
            DataContext.SaveChanges();
        }

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }
    }
}
