namespace Infrastructure.Services;
using Infrastructure.Context;
using Domain.Entities;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
public class TodoListImagesService
{
    public readonly DataContext _context;
    public TodoListImagesService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetTodoListImage>> GetTodoListImages()
    {
       var list  = await _context.TodoListImages.Select(t => new GetTodoListImage()
        {
            Id = t.Id,
        ImageName = t.ImageName,
        Title = t.TodoList.Title,
        Color = t.TodoList.Color
        }).ToListAsync();
        
        return list;
    }
    public async Task<AddTodoListImage> Add(AddTodoListImage todo)
    {
        var newTodo = new TodoListImage()
        { ImageName = todo.ImageName ,
            TodoListId = todo.TodoListId  

        };
        _context.TodoListImages.Add(newTodo);
        await _context.SaveChangesAsync();
        return todo;
    }
    public async Task<AddTodoListImage> Update (AddTodoListImage todo)
    {
    

     var find = await _context.TodoListImages.FindAsync(todo.Id);
        if(find == null ) return new AddTodoListImage();
         find.ImageName = todo.ImageName;
       find.TodoListId = todo.TodoListId;
       
        await _context.SaveChangesAsync();

        return todo;
    }
    public async Task<string> Delete(int id)
    {
        var find = await _context.TodoListImages.FindAsync(id);
         _context.TodoListImages.Remove(find);
        await _context.SaveChangesAsync();
        return "Deleted";

    }
}