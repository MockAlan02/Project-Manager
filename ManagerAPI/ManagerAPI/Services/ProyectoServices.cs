using ManagerAPI.Model;
using ManagerAPI.Repositorio;
using Persistencia.Context;

namespace ManagerAPI.Services
{
    public class ProyectoServices
    {
        private readonly ProyectoManager _proyectoServices;
        public ProyectoServices(ProjectManagerContext context)
        {
            _proyectoServices = new(context);
        }


        public void CrearProyecto(Proyectos proyecto)
        {
            _proyectoServices.Insert(proyecto);
        }
        public void EliminarProyecto(int id)
        {
            _proyectoServices.Delete(id);
        }
        public void ActualizarProyecto(int id, Proyectos proyecto)
        {
            _proyectoServices.Update(id, proyecto);
        }
        public List<Proyectos> GetAll()
        {
            return _proyectoServices.GetAll();
        }
    }
}
