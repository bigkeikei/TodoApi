using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("")]
    public class WelcomeController : Controller
    {
        [HttpGet]
        public IActionResult get()
        {
            return Content("Welcome to TodoApi");
        }
    }

    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        [FromServices]
        public ITodoRepository TodoItems { get; set; }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            TodoItem item = TodoItems.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Add([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            TodoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { controller = "Todo", id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || id != item.Id)
            {
                return HttpBadRequest();
            }
            if (TodoItems.Find(id) == null)
            {
                return HttpNotFound();
            }
            TodoItems.Update(item);
            return new NoContentResult();
        }

        [HttpGet("[action]")]
        public IActionResult Testing()
        {
            return Content("Hello world!");
        }
    }
}
