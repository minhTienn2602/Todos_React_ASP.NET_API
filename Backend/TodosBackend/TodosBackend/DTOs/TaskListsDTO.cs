using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodosBackend.DTOs
{
    public class TaskListsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsCompleted { get; set; } 
       
        public DateTime WorkDate { get; set; } 
    }
}
