using ManagerAPI.Dto;
using ManagerAPI.Model;
using ManagerAPI.Repositorio;

namespace ManagerAPI.Services
{
    public class TareaServices
    {
        private readonly TareasManager? _tareaServices;
        private readonly UsuarioManager? _suarioService;
        private readonly AsignacionManager? _asignacionServices;
        public TareaServices(string pathJson, string PathAsignation)
        {
            _tareaServices = new(pathJson);
            _asignacionServices = new(PathAsignation);
            _suarioService = new("./Json/Usuarios.json");
        }
        
        public Tarea CrearTarea(Tarea tarea)
        {
            return _tareaServices?.Guardar(tarea)!;
        }
        public Tarea CrearTarea(TareaDto tarea)
        {
            var tareaId = _tareaServices?.GetAll().Count() + 1 ?? 0;
            var tareas = new Tarea
            {
                Id = tareaId,
                ProyectoId = tarea.ProyectoId,
                Detalles = tarea.Detalles,
                ExpireTime = tarea.ExpireTime,
                Estado = tarea.Estado,

            };
            var asignacion = new AsignacionTarea
            {
                UsuarioId = tarea.PersonaId,
                TareaId = tareaId
            };
            _asignacionServices?.Guardar(asignacion);
            return _tareaServices?.Guardar(tareas)!;
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
        public List<Tarea> GetByProyectoId(int proyectoId)
        {
            return _tareaServices?.BuscarProyctoId(proyectoId)!;
        }
        public DetallesDto Detalles(int id)
        {
            var tarea = _tareaServices?.BuscarPorId(id);
            var asignacion = _asignacionServices?.BuscarPorTarea(id);
            var cliente = _suarioService?.BuscarPorId(asignacion!.UsuarioId);
            return new DetallesDto
            {
                Nombre = cliente?.UserDetail!.Nombre,
                Estado = tarea!.Estado,
                Detalles = tarea.Detalles,
                ExpireTime = tarea.ExpireTime,
            };
        }
    }
}
