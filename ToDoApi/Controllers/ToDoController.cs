using Microsoft.AspNetCore.Mvc;
using ToDoApi.Data;
using ToDoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ToDoApi.Controllers;


[Route("api/todo")]
[ApiController]
public class ToDoController : Controller
{
    public ToDoController()
    {

    }

    [HttpGet]
    public async Task<ActionResult> Index(ApplicationDBContext db)
    {
        var todos = db.ToDos.ToList();
        return Ok(todos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetTodo(ApplicationDBContext db, int id)
    {
        var todo = await db.ToDos.FirstOrDefaultAsync(td => td.Id == id);

        if (todo is null)
            return NotFound();

        return Ok(todo);
    }

    [HttpPost]
    public async Task<ActionResult> CreateTodo(ApplicationDBContext db, ToDo todo)
    {
        db.ToDos.Add(todo);
        await db.SaveChangesAsync();
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTodo(ApplicationDBContext db, ToDo updateTodo, int id)
    {
        var todo = await db.ToDos.SingleOrDefaultAsync(p => p.Id == id);
        if (todo is null)
            return NotFound();
        todo.Title = updateTodo.Title;
        todo.IsDone = updateTodo.IsDone;
        db.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTodo(ApplicationDBContext db, int id)
    {
        var todo = await db.ToDos.SingleOrDefaultAsync(p => p.Id == id);
        if (todo is null)
            return NotFound();
        db.ToDos.Remove(todo);
        await db.SaveChangesAsync();

        return NoContent();
    }

}