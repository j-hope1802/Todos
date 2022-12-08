using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;

public class DataContext:DbContext
{
 public DataContext(DbContextOptions<DataContext> options) : base(options)
 {

 }
 public DbSet<Todo> Todo {get; set;}
  public DbSet <TodoList> TodoList {get; set;}

  public DbSet<TodoListImage> TodoListImages{get;set;}


}