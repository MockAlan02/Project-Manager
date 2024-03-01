using ManagerAPI.Model;
using ManagerAPI.Repositorio;

namespace ManagerAPI.Services
{
    public class ProyectoServices
    {
        private readonly ProyectoManager _proyectoServices;
        public ProyectoServices(string pathJson)
        {
            _proyectoServices = new(pathJson);
        }


        public Proyectos CrearProyecto(Proyectos proyecto)
        {
            return _proyectoServices.Guardar(proyecto);
        }
        public void EliminarProyecto(int id)
        {
            _proyectoServices.Delete(id);
        }
        public Proyectos ActualizarProyecto(int id, Proyectos proyecto)
        {
            return _proyectoServices.Actualizar(id, proyecto);
        }
        public List<Proyectos> GetAll()
        {
            return _proyectoServices.GetAll();
        }
    }
}
