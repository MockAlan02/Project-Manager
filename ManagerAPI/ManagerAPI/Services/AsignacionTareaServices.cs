using ManagerAPI.Model;
using ManagerAPI.Repositorio;

namespace ManagerAPI.Services
{
    public class AsignacionTareaServices
    {
        private readonly AsignacionManager? _asignacionService;
        public AsignacionTareaServices(string pathJson)
        {
            _asignacionService = new(pathJson);
        }
        public AsignacionTarea CrearAsignacion(AsignacionTarea tarea)
        {
            return _asignacionService?.Guardar(tarea)!;
        }
        public void CrearAsignacion(List<AsignacionTarea> tarea)
        {
            _asignacionService!.Guardar(tarea);
        }
        public AsignacionTarea ActualizarAsignacion(int id, AsignacionTarea tarea)
        {
            return _asignacionService?.Actualizar(id, tarea)!;
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
