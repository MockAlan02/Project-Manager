
using ManagerAPI.Model;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;
using Persistencia.Interfaz;


namespace ManagerAPI.Repositorio
{
    public class AsignacionManager : IRepository<AsignacionTarea>
    {
        private readonly ProjectManagerContext _project;

        public AsignacionManager(ProjectManagerContext project)
        { 
            _project = project;
        }
        //Eliminar un registro a traves del Id
        public void Delete(int id)
        {
           if(id != null)
            {
                var asign = _project.AsignacionUsuario.FirstOrDefault(asign => asign.Id == id);
               _project.AsignacionUsuario.Remove(asign!);
                _project.SaveChanges();
            }
        }
        //Conseguir todo los registros
        public List<AsignacionTarea> GetAll()
        {
            return _project.AsignacionUsuario.ToList();
        }
        //Buscar Asignacion por id de la tarea
        public AsignacionTarea BuscarPorTarea(int id)
        {
            return _project.AsignacionUsuario.FirstOrDefault(asign => asign.IdTarea == id)!;
        }
        //Eliminar Asignacion a traves del id de la tarea
        public void BorrarPorTareaId(int id)
        {
            var asign = _project.AsignacionUsuario.FirstOrDefault(asign => asign.IdTarea == id);
            _project.AsignacionUsuario.Remove(asign!);
            _project.SaveChanges();
        }
        //Conseguir informacion a traves del Id
        public AsignacionTarea GetById(int id)
        {
            return _project.AsignacionUsuario.FirstOrDefault(asign => asign.Id == id)!;
        }
        //Crear un Usuario Nuevo
        public void Insert(AsignacionTarea entity)
        {
            _project.AsignacionUsuario.Add(entity);
            _project.SaveChanges();
        }

        //Actualizar el usuario
        public void Update(int id,AsignacionTarea newData)
        {
            if (newData != null && id != null)
            {
                var asignaciones = GetById(id);
                _project.Entry(asignaciones).CurrentValues.SetValues(newData);
                _project.SaveChanges();
            }
        }
}
}
