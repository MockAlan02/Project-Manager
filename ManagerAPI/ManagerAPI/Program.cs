using ManagerApi.Core.Interface;
using ManagerApi.Core.Services;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
using Persistencia.Repositories;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your database context and database provider strategy

builder.Services.AddDbContext<ProjectManagerContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

//Pattern UnitOfWork
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

//Generic Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

builder.Services.AddScoped<IHomeworkService, HomeworkService>();
builder.Services.AddScoped<IProyectoService, ProyectoService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true)); // Allow any origin  

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
