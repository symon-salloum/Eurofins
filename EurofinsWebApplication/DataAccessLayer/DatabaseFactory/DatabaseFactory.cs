using BusinessLayer;
using DataAccessLayer.Context;
using System;

namespace DataAccessLayer.DatabaseFactory
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {

        private readonly DatabaseContext _dbContext;

        public DatabaseFactory()
        {
            _dbContext = new DatabaseContext();
        }

        public DatabaseContext GetDatabaseContext()
        {
            return _dbContext ?? new DatabaseContext();
        }

        protected override void DisposeCore()
        {
            _dbContext.Dispose();
        }
    }
}
