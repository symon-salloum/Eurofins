using BusinessLayer.Domain.ToDoTask;
using System.ComponentModel.DataAnnotations.Schema;
using System.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace DataAccessLayer.Configuration
{
    public class ToDoTaskConfiguration : EntityTypeConfiguration<ToDoTask>
    {
        public ToDoTaskConfiguration()
        {
            ToTable("ToDoTasks");
            Property(p => p.Id).IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Title).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(p => p.Description).IsRequired().HasColumnType("nvarchar").HasMaxLength(1000);
            Property(p => p.IsCompleted).IsRequired().HasColumnType("bit");
        }
    }
}
