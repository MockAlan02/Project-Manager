using System.Reflection;
using ManagerApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data;

public partial class ProjectManagerContext : DbContext
{
    public ProjectManagerContext()
    {
    }

    public ProjectManagerContext(DbContextOptions<ProjectManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsignacionUsuario> AsignacionUsuarios { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioDetalle> UsuarioDetalles { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
