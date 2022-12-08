namespace Infrastructure.Services;
using Infrastructure.Context;
using Domain.Entities;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
public class TodoListService
{
    public readonly DataContext _context;
    public TodoListService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetTodoList>> GetTodos()
    {
       var list  = await _context.TodoList.Select(t => new GetTodoList()
        {
            Id = t.Id,
            Title = t.Title,
            Color=t.Color
            
        }).ToListAsync();
        
        return list;
    }
    public async Task<AddTodoList> Add(AddTodoList todo)
    {
        var newTodo = new TodoList()
        {
          
            Title = todo.Title,
            Color=todo.Color

        };
        _context.TodoList.Add(newTodo);
        await _context.SaveChangesAsync();
        return todo;
    }
    public async Task<AddTodoList> Update(AddTodoList todo)
    {
        var find = await _context.TodoList.FindAsync(todo.Id);

        if(find == null) return new AddTodoList();
           find.Title = todo.Title;
         find.Color = todo.Color;
        await _context.SaveChangesAsync();
        return todo;
    }
    public async Task<string> Delete(int id)
    {
        var find = await _context.TodoList.FindAsync(id);
         _context.TodoList.Remove(find);
        await _context.SaveChangesAsync();
        return "Deleted";

    }
}