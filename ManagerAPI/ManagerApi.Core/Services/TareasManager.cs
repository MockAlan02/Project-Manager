using ManagerAPI.Dto;
using ManagerAPI.Model;
using Microsoft.Identity.Client;
using Persistencia.Context;
using Persistencia.Interfaz;
using System.Threading;

namespace ManagerAPI.Repositorio
{
    public class TareasManager : IRepository<Tarea>
    {
        private readonly ProjectManagerContext _project;                

        public TareasManager(ProjectManagerContext project) {
          
            _project = project;
        }
        
        public Tarea GetByDetails(string  details)
        {
            return _project.Tarea.FirstOrDefault(tare => tare.Detalles == details)!;
        }
       
        public List<Tarea> GetProjectId(int id)
        {
            return _project.Tarea.Where(tare => tare.ProyectoId == id).ToList();
        }

        public List<Tarea> GetAll()
        {

            var tareas = (from tarea in _project.Tarea select tarea).ToList();
            return tareas;
        }

      
        public void Delete(int id)
        {
            if(id  != null)
            {
                var task = GetById(id);
                _project.Tarea.Remove(task);
                _project.SaveChanges();
            }
        }

        public Tarea GetById(int id)
        {
            return _project.Tarea.FirstOrDefault(tarea => tarea.Id == id)!;
        }

        public void Insert(Tarea entity)
        {
            _project.Tarea.Add(entity);
            _project.SaveChanges();
        }

        public void Update(int id, Tarea newData)
        {
            if(id != null && newData != null)
            {
                var task = GetById(id);
                _project.Entry(task).CurrentValues.SetValues(newData);
            }
        }
        public DetallesDto DetallesDto(int id)
        {
            DetallesDto detalles = (from tarea in _project.Tarea
                            join asignacion in _project.AsignacionUsuario on tarea.Id equals asignacion.IdTarea
                            join usuario in _project.Usuario on asignacion.IdUsuario equals usuario.Id
                            join usuarioDetalle in _project.UsuarioDetalle on usuario.IdUsuarioDetalles equals usuarioDetalle.Id
                            where tarea.Id == id // Puedes agregar condiciones adicionales aquí
                            select new DetallesDto
                            {
                              Nombre = usuarioDetalle.Nombre,
                              Estado = tarea.Estado,
                              Detalles = tarea.Detalles,
                              ExpireTime = tarea.ExpireTime
                                // Otros campos que necesites
                            }).FirstOrDefault(); // O cualquier otro método de consulta que necesites

            return detalles!;
        }

    }
}
