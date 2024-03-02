using ManagerAPI.Model;
using ManagerAPI.Repositorio;

namespace ManagerAPI.Services
{
    public class TareaServices
    {
        private readonly TareasManager? _tareaServices;
        public TareaServices(string pathJson)
        {
            _tareaServices = new(pathJson);
        }
        public Tarea CrearTarea(Tarea tarea)
        {
            return _tareaServices?.Guardar(tarea)!;
        }
        public Tarea ActualizarTarea(int id, Tarea tarea)
        {
            return _tareaServices?.Actualizar(id, tarea)!;
        }
        public void BorrarTarea(int id)
        {
            _tareaServices?.Delete(id);
        }
        public List<Tarea> GetAll()
        {
            return _tareaServices!.GetAll();
        }
        public Tarea GetById(int id)
        {
            return _tareaServices?.BuscarPorId(id)!;
        }
    }
}
