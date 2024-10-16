using Microsoft.EntityFrameworkCore;
using TodosBackend;
using TodosBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodosDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TodosConnectionString")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Shows UseCors withCorsPolicyBuilder
app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Seed dữ liệu sau khi khởi tạo ứng dụng
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TodosDbContext>();

    // Gọi phương thức Seed để thêm dữ liệu vào database
    FirstGeneration.Seed(context);
}

app.Run();
