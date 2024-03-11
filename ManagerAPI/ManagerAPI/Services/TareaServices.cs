using ManagerAPI.Dto;
using ManagerAPI.Model;
using ManagerAPI.Repositorio;
using Microsoft.AspNetCore.Components.Forms;
using Persistencia.Context;
using System.Threading;

namespace ManagerAPI.Services
{
    public class TareaServices
    {
        private readonly TareasManager? _tareaServices;
        private readonly UsuarioManager? _usuarioServices;
        private readonly AsignacionManager? _asignacionServices;
        public TareaServices(ProjectManagerContext tareaContext, ProjectManagerContext asignContext)
        {
            _tareaServices = new(tareaContext);
            _asignacionServices = new(asignContext);
            _usuarioServices = new(asignContext);
        }

        public void CrearTarea(Tarea tarea)
        {
            _tareaServices?.Insert(tarea);
        }
        public Tarea CrearTarea(TareaDto tarea)
        {

            var tareas = new Tarea
            {
                ProyectoId = tarea.ProyectoId,
                Detalles = tarea.Detalles,
                ExpireTime = tarea.ExpireTime,
                Estado = tarea.Estado
            };
            //Inserta el dato en la base de datos
            _tareaServices?.Insert(tareas);


          

            //Conseguir el id
            int tareaId = tareas.Id;

            // Crear una nueva asignación de tarea con el ID de la tarea
            var asignacion = new AsignacionTarea
            {
                IdUsuario = tarea.PersonaId,
                IdTarea = tareaId
            };

            // Guardar la asignación de tarea en la base de datos
            _asignacionServices?.Insert(asignacion);

            // Devolver la tarea guardada
            return tareas;
        }

    
        public void ActualizarTarea(int id, Tarea tarea)
        {
           _tareaServices?.Update(id, tarea);
        }
        //Esta funcion se encarga que si necesito eliminar una tarea se borre del registro de asignaciones
        public void BorrarTarea(int id)
        {
            _asignacionServices?.BorrarPorTareaId(id);
            _tareaServices?.Delete(id);
        }

        //Conseguir todo los registros
        public List<Tarea> GetAll()
        {
            return _tareaServices!.GetAll();
        }

        //Conseguir la tarea por el Id
        public Tarea GetById(int id)
        {
            return _tareaServices?.GetById(id)!;
        }

        //Recibir Todas las tareas a traves del Id Project
        public List<Tarea> GetByProyectoId(int proyectoId)
        {
            return _tareaServices?.GetProjectId(proyectoId)!;
        }

        public DetallesDto Detalles(int id)
        {
            if(id != null)
            {
                var detalles =  _tareaServices?.DetallesDto(id);
                return new DetallesDto
                {
                    Estado = detalles.Estado,
                    Detalles = detalles.Detalles,
                    ExpireTime = detalles.ExpireTime,
                    Nombre = detalles.Nombre
                };
            }
            return null!;
        }
    }
}
