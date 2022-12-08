using System.Net;
namespace WebApi.Controllers;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TodoListImagesController
{
    private readonly TodoListImagesService _TodoListImagesService;

    public TodoListImagesController(TodoListImagesService TodoListImagesService)
    {
        _TodoListImagesService = TodoListImagesService;
    }
    
    [HttpGet]
    public async Task<List<GetTodoListImage>> GetTodoListImages()
    {
        return  await _TodoListImagesService.GetTodoListImages();
    }
    
    [HttpPost]
    public async Task<AddTodoListImage> Post(AddTodoListImage Todo)
    {
        return await _TodoListImagesService.Add(Todo);
    }
    [HttpPut]
    public async Task<AddTodoListImage> Update(AddTodoListImage todo)
    {
        return await _TodoListImagesService.Update(todo);
    }
    [HttpDelete]
    public async Task<string> Delete(int id)
    {
        return await _TodoListImagesService.Delete(id);
    }
   
    
}