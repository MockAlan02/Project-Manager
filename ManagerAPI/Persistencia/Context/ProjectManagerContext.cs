using ManagerAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistencia.Context
{
    public class ProjectManagerContext : DbContext
    {
        public DbSet<Tarea> Tarea { get; set; }
        public DbSet<Proyectos> Proyecto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioDetail> UsuarioDetalle { get; set; }
        public DbSet<AsignacionTarea> AsignacionUsuario { get; set; }

        public ProjectManagerContext(DbContextOptions<ProjectManagerContext> options) : base(options)
        {
            
        }

        public ProjectManagerContext(DbContextOptions options) : base(options)
        {
        }
    }
}
