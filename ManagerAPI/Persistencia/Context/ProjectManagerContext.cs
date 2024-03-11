using ManagerAPI.Model;
using Microsoft.EntityFrameworkCore;
using Persistencia.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Context
{
    public class ProjectManagerContext : DbContext
    {
        public DbSet<Tarea> Tarea { get; set; }
        public DbSet<Proyectos> Proyecto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioDetail> UsuarioDetalle { get; set; }
        public DbSet<AsignacionTarea> AsignacionUsuario { get; set; }
        private readonly IDatabaseProviderStrategy _databaseProviderStrategy;
        private readonly string _connectionString;

        public ProjectManagerContext(DbContextOptions<ProjectManagerContext> options) : base(options)
        {
            
        }

        public ProjectManagerContext(DbContextOptions options) : base(options)
        {
        }
    }
}
