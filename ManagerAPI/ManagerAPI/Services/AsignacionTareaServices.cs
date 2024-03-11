using ManagerAPI.Model;
using ManagerAPI.Repositorio;
using Persistencia.Context;

namespace ManagerAPI.Services
{
    public class AsignacionTareaServices
    {
        private readonly AsignacionManager? _asignacionService;
        public AsignacionTareaServices(ProjectManagerContext context)
        {
            _asignacionService = new(context);
        }
        public void CrearAsignacion(AsignacionTarea tarea)
        {
            _asignacionService?.Insert(tarea);
        }
    
        public void ActualizarAsignacion(int id, AsignacionTarea tarea)
        {
            _asignacionService?.Update(id, tarea);
        }
        public void BorrarAsignacion(int id)
        {
            _asignacionService?.Delete(id);
        }
        public List<AsignacionTarea> GetAll()
        {
            return _asignacionService?.GetAll()!;
        }
    }
}
