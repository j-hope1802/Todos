using System.Net;
namespace WebApi.Controllers;

using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TodoController
{
    private readonly TodoService _TodoService;

    public TodoController(TodoService TodoService)
    {
        _TodoService = TodoService;
    }
    
    [HttpGet]
    public async Task<List<GetTodo>> Get()
    {
        return  await _TodoService.GetTodo();
    }
    
    [HttpPost]
    public async Task<AddTodo> Post(AddTodo Todo)
    {
        return await _TodoService.Add(Todo);
    }
    [HttpPut]
    public async Task<AddTodo> Update(AddTodo todo)
    {
        return await _TodoService.Update(todo);
    }
    [HttpDelete]
    public async Task<string> Delete(int id)
    {
        return await _TodoService.Delete(id);
    }
   
    
}