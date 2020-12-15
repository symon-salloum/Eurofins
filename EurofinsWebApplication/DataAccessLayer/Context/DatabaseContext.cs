using BusinessLayer.Domain.ToDoTask;
using DataAccessLayer.Configuration;
using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccessLayer.Context
{
    public class DatabaseContext : DbContext
    {

        public DbSet<ToDoTask> ToDoTasks { set; get; }
        public DatabaseContext() : base(GetConnection(), false)
        {

        }

        private static DbConnection GetConnection()
        {
            var connection = ConfigurationManager.ConnectionStrings["SQLiteConnection"];
            var factory = DbProviderFactories.GetFactory(connection.ProviderName);
            var dbCon = factory.CreateConnection();
            dbCon.ConnectionString = connection.ConnectionString;
            return dbCon;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ToDoTaskConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
