using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodosBackend.Data;
using TodosBackend.DTOs;
using TodosBackend.Models;

namespace TodosBackend.Controllers
{
    [Route("v1/api/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public readonly TodosDbContext _dbContext;
        public TodoController(TodosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // Get all tasks in TaskLists table
        [HttpGet]
        public IActionResult GetAllTask()
        {
            // Lấy ngày hiện tại
            DateTime today = DateTime.Today;

            // Lấy các công việc có WorkDate bằng với ngày hiện tại, sắp xếp theo Id giảm dần
            var tasks = _dbContext.TaskLists
                                  .Where(t => t.WorkDate.Date == today) // Lọc theo ngày hiện tại
                                  .OrderByDescending(t => t.Id)         // Sắp xếp theo Id giảm dần
                                  .ToList();

            return Ok(tasks); // Trả về kết quả
        }


        //Get a task in TaskLists table by Id
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetTaskById([FromRoute] int id)
        {
            var task = _dbContext.TaskLists.FirstOrDefault(t => t.Id == id);
            if (task == null) {
                return NotFound();
            }
            TaskListsDTO taskListDTO = new TaskListsDTO()
            {
                Id = task.Id,
                Name = task.Name,
                IsCompleted = task.IsCompleted,
                WorkDate = task.WorkDate
            };
            return Ok(taskListDTO);
        }

        //Add a task into TaskList
        [HttpPost]
        public IActionResult AddTask([FromBody] AddTaskListsDTO tasks)
        {
            var tasklistModels = new TaskList()
            {
                Name = tasks.Name,
                IsCompleted = false,
                WorkDate = DateTime.Now
            };
            _dbContext.TaskLists.Add(tasklistModels);
            _dbContext.SaveChanges();
            
            return Ok();
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateTask([FromRoute] int id, [FromBody] UpdateTaskListsDTO updateTaskDTO)
        {
            var taskModels=_dbContext.TaskLists.FirstOrDefault(task => task.Id == id);
            if(taskModels == null)
            {
                return NotFound();
            }
            taskModels.Name = updateTaskDTO.Name;
            taskModels.IsCompleted = updateTaskDTO.IsCompleted;
            _dbContext.SaveChanges();
            var task = new TaskListsDTO()
            {
                Id = taskModels.Id,
                Name = updateTaskDTO.Name,
                IsCompleted = updateTaskDTO.IsCompleted,
                WorkDate = taskModels.WorkDate
            };
            return Ok(task);
            
        }
        //Delele a task by Id
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var taskModel = _dbContext.TaskLists.FirstOrDefault(x => x.Id == id);
            if (taskModel == null)
            {
                return NotFound();
            }
            
            _dbContext.TaskLists.Remove(taskModel);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
