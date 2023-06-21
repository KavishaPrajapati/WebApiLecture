using Microsoft.EntityFrameworkCore;
using WebApiLecture.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbCon...
builder.Services.AddDbContext<EmployeeContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("ConEmp")));
builder.Services.AddCors(cors => cors.AddPolicy("mypolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("mypolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
