using System.Data.Entity;
using MySql.Data.Entity;

namespace TodoApi.Models.MySql
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class TodoMySqlContext: DbContext
    {
        public TodoMySqlContext(string connectionString) : base(connectionString) { }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
