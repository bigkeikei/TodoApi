using System.Collections.Generic;

namespace TodoApi.Models
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> GetAll();
        void Add(TodoItem item);
        TodoItem Find(string key);
        void Update(TodoItem item);
        TodoItem Remove(string key);
    }
}