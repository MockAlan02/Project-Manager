using ManagerApi.Core.Entities;
using ManagerApi.Core.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Persistencia.Repositories
{
    public class AsignacionUsuarioRepository : BaseRepository<AsignacionUsuario>, IAsignacionUsuarioRepository
    {
        public AsignacionUsuarioRepository(ProjectManagerContext context) : base(context)
        {
        }
        public async Task DeleteByTareaId(int id)
        {
            var tarea = await _entities.FirstOrDefaultAsync(ta => ta.IdTarea == id);
            _entities.Remove(tarea!);
        }
        public async Task<AsignacionUsuario> GetByTareaId(int id)
        {
            var asignaciones = await _entities.FirstOrDefaultAsync(asign => asign.IdTarea == id);
            return asignaciones;
        }
    }
}
