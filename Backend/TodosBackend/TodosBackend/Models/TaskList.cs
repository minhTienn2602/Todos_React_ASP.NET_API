using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodosBackend.Models
{
    [PrimaryKey("Id")]
    public class TaskList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public bool IsCompleted { get; set; } = false;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime WorkDate { get; set; } = DateTime.Now;
    }
}
