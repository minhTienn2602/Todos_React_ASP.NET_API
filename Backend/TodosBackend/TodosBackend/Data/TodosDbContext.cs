using Microsoft.EntityFrameworkCore;
using TodosBackend.Models;

namespace TodosBackend.Data
{
    public class TodosDbContext:DbContext
    {
       public TodosDbContext(DbContextOptions<TodosDbContext> options) : base(options) { 
        }
        public DbSet<TaskList> TaskLists { get; set; }


    }
}
