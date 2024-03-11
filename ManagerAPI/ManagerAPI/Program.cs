using ManagerAPI.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistencia.Context;
using Persistencia.Interfaz;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
// Set up the invariant culture
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your database context and database provider strategy

builder.Services.AddDbContext<SqlContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

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
