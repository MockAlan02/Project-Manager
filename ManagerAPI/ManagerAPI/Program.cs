using ManagerApi.Core.Interface;
using ManagerApi.Core.Services;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
using Persistencia.Filters;
using Persistencia.Repositories;
using FluentValidation.AspNetCore;
using Persistencia.Mapping;

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

//Configure Personalizada en appsettings, mapping values from
builder.Services.AddAutoMapper(typeof(MapperProfile));
//Generic Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

builder.Services.AddScoped<IHomeworkService, HomeworkService>();
builder.Services.AddScoped<IProyectoService, ProyectoService>();

#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add<ValidationFilter>();
}).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ValidationFilter>());
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos

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
