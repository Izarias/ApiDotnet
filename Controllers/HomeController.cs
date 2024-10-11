using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers{
    [ApiController]
    [Route("home")]
    public class HomeController: ControllerBase{
        [HttpGet("/get")]
        public List<TodoModel> Get([FromServices] AppDbContext context)
        {
            return context.Todos.ToList();
        }

        [HttpPost("/post")]
        public TodoModel Post(
            [FromBody] TodoModel todo,
            [FromServices] AppDbContext context
        ){
            context.Todos.Add(todo);
            context.SaveChanges();
            return todo;
        }

        [HttpGet("/{id:int}")]
        public TodoModel GetById([FromRoute] int id, [FromServices] AppDbContext context)
        {
            return context.Todos.FirstOrDefault(x=>x.Id == id);
        }
    }
}