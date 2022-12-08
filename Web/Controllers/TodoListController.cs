using System.Net;
namespace WebApi.Controllers;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TodoListController
{
    private readonly TodoListService _TodoListService;

    public TodoListController(TodoListService todoListService)
    {
        _TodoListService = todoListService;
    }
    
    [HttpGet]
    public async Task<List<GetTodoList>> Get()
    {
        return  await _TodoListService.GetTodos();
    }
    
    [HttpPost]
    public async Task<AddTodoList> Post(AddTodoList Todo)
    {
        return await _TodoListService.Add(Todo);
    }
    [HttpPut]
    public async Task<AddTodoList> Update(AddTodoList todo)
    {
        return await _TodoListService.Update(todo);
    }
    [HttpDelete]
    public async Task<string> Delete(int id)
    {
        return await _TodoListService.Delete(id);
    }
   
    
}