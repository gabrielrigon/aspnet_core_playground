using TodoApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TodoApi.Services
{
  public class TodoService
  {
    private readonly IMongoCollection<TodoItem> _todoItems;

    public TodoService(ITodoDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _todoItems = database.GetCollection<TodoItem>(settings.TodosCollectionName);
    }

    public List<TodoItem> Get() =>
      _todoItems.Find(todo => true).ToList();

    public TodoItem Get(string id) =>
      _todoItems.Find<TodoItem>(todo => todo.Id == id).FirstOrDefault();

    public TodoItem Create(TodoItem todoItem)
    {
      _todoItems.InsertOne(todoItem);
      return todoItem;
    }

    public void Update(string id, TodoItem todoItemIn) =>
      _todoItems.ReplaceOne(todoItem => todoItem.Id == id, todoItemIn);

    public void Remove(TodoItem todoItemIn) =>
      _todoItems.DeleteOne(todoItem => todoItem.Id == todoItemIn.Id);

    public void Remove(string id) =>
      _todoItems.DeleteOne(todoItem => todoItem.Id == id);
  }
}