using System;
using System.Collections.Generic;

namespace TodoApi.Models
{
    public class TodoRepositoryEF : ITodoRepository
    {
        public TodoContext _todoContext { get; set; }

        public TodoRepositoryEF(TodoContext context)
        {
            _todoContext = context;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todoContext.TodoItems;
        }

        public void Add(TodoItem item)
        {
            item.Id = Guid.NewGuid().ToString();
            _todoContext.TodoItems.Add(item);
            _todoContext.SaveChanges();
        }

        public TodoItem Find(string id)
        {
            return _todoContext.TodoItems.Find(id);
        }

        public TodoItem Remove(string id)
        {
            TodoItem item = _todoContext.TodoItems.Find(id);
            if (item != null)
            {
                _todoContext.TodoItems.Remove(item);
                _todoContext.SaveChanges();
            }
            return item;
        }

        public void Update(TodoItem item)
        {
            TodoItem itemToUpdate = _todoContext.TodoItems.Find(item.Id);
            itemToUpdate.Name = item.Name;
            itemToUpdate.IsComplete = item.IsComplete;
            itemToUpdate.TargetDate = item.TargetDate;
            _todoContext.SaveChanges();
            return;
        }
    }
}