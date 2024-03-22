using ManagerApi.Core.Interface;
using ManagerAPI.Core.Entities;
using ManagerAPI.Core.Interface;
using Persistencia.Context;


namespace Persistencia.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectManagerContext _context;
        private readonly IRepository<Tarea> _homeworkService = null!;
        private readonly IRepository<Proyectos> _proyectoService = null!;
        public UnitOfWork(ProjectManagerContext context)
        {
            _context = context;
        }

        public IRepository<Tarea> HomeworkService => _homeworkService ?? new BaseRepository<Tarea>(_context);
        public IRepository<Proyectos> ProyectoService => _proyectoService ?? new BaseRepository<Proyectos>(_context);

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
