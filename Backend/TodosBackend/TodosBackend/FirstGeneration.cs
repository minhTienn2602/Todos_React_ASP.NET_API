using TodosBackend.Data;
using TodosBackend.Models;

namespace TodosBackend
{
    public class FirstGeneration
    {
        // Phương thức để seed dữ liệu
        public static void Seed(TodosDbContext context)
        {
            // Kiểm tra nếu bảng TaskLists đã có dữ liệu thì không thêm nữa
            if (!context.TaskLists.Any())
            {
                List<TaskList> tasks = new List<TaskList>()
                {
                    new TaskList { Name = "Learn ASP.NET", IsCompleted = false, WorkDate = DateTime.Now },
                    new TaskList { Name = "Learn HTML and CSS", IsCompleted = false, WorkDate = DateTime.Now },
                    new TaskList { Name = "Work on Band App", IsCompleted = true, WorkDate = DateTime.Now.AddDays(-5) }
                };

                // Thêm danh sách task vào database
                context.TaskLists.AddRange(tasks);

                // Lưu thay đổi vào database
                context.SaveChanges();
            }
        }
    }
}
