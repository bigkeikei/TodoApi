using System.Data.Entity;
using MySql.Data.Entity;

namespace TodoApi.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class TodoMySqlContext: TodoContext
    {
        public TodoMySqlContext(string connectionString) : base(connectionString) { }
    }

    public class TodoContext : DbContext
    {
        public TodoContext(string connectionString) : base(connectionString) { }
        public DbSet<TodoItem> TodoItems { get; set; }
    }

}
