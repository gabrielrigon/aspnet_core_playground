using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TodoController : ControllerBase
  {
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
      _todoService = todoService;
    }

    [HttpGet]
    public ActionResult<List<TodoItem>> GetTodoItems() =>
      _todoService.Get();

    [HttpGet("{id:length(24)}", Name = "GetTodoItem")]
    public ActionResult<TodoItem> GetTodoItem(string id)
    {
      var todoItem = _todoService.Get(id);

      if (todoItem == null)
      {
        return NotFound();
      }

      return todoItem;
    }

    [HttpPost]
    public ActionResult<TodoItem> PostTodoItem(TodoItem item)
    {
      _todoService.Create(item);
      return CreatedAtRoute("GetTodoItem", new { id = item.Id.ToString() }, item);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult PutTodoItem(string id, TodoItem itemIn)
    {
      var todoItem = _todoService.Get(id);

      if (todoItem == null)
      {
        return NotFound();
      }

      _todoService.Update(id, itemIn);

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult DeleteTodoItem(string id)
    {
      var todoItem = _todoService.Get(id);

      if (todoItem == null)
      {
        return NotFound();
      }

      _todoService.Remove(todoItem.Id);

      return NoContent();
    }
  }
}