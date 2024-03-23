using ManagerApi.Core.Entities;
using ManagerApi.Core.Interface;
using Persistencia.Data;

namespace Persistencia.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectManagerContext _context;
        private readonly IHomeworkRepository _homeworkService = null!;
        private readonly IRepository<Proyecto> _proyectoService = null!;
        private readonly IAsignacionUsuarioRepository _asignacionRepo = null!;
        private readonly IRepository<Usuario> _usuarioService = null!;
        private readonly IRepository<UsuarioDetalle> _usuarioDeatilService = null!;
        public UnitOfWork(ProjectManagerContext context)
        {
            _context = context;
        }

        public IHomeworkRepository HomeworkService => _homeworkService ?? new HomeworkRepository(_context);
        public IRepository<Proyecto> ProyectoService => _proyectoService ?? new BaseRepository<Proyecto>(_context);
        public IRepository<Usuario> UsuarioService => _usuarioService ?? new BaseRepository<Usuario>(_context);
        public IRepository<UsuarioDetalle> UsuarioDetailService => _usuarioDeatilService ?? new BaseRepository<UsuarioDetalle>(_context);
        public IAsignacionUsuarioRepository AsignacionRepo => _asignacionRepo ?? new AsignacionUsuarioRepository(_context);

     

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
