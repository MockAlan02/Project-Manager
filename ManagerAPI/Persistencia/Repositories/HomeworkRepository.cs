

using ManagerApi.Core.Entities;
using ManagerApi.Core.Interface;
using Persistencia.Data;

namespace Persistencia.Repositories
{
    public class HomeworkRepository : BaseRepository<Tarea>, IHomeworkRepository
    {
        public HomeworkRepository(ProjectManagerContext context) : base(context)
        {
        }
        public IEnumerable<Tarea> GetByProyectoId(int id)
        {
            var tareas = _entities.Where(ta => ta.ProyectoId == id);
            return tareas;
        }
    }
}
