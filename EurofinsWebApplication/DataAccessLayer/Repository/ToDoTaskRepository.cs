using BusinessLayer.Domain.ToDoTask;
using BusinessLayer.Repository.ToDoTask;
using DataAccessLayer.DatabaseFactory;

namespace DataAccessLayer.Repository
{
    public class ToDoTaskRepository : Repository<ToDoTask>, IToDoTaskRepository
    {
        public ToDoTaskRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
