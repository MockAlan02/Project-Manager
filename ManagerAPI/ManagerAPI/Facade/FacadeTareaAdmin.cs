using ManagerAPI.Dto;
using ManagerAPI.Model;
using ManagerAPI.Repositorio;
using ManagerAPI.Services;
using Persistencia.Context;
using Persistencia.Dto;

namespace ManagerAPI.Facade
{
    public class FacadeTareaAdmin
    {
        public ProyectoServices ProyectoServices { get; private set; }
        private readonly TareaServices _tareaManager;
        private readonly UsuarioService _usuarioManager;
        public  TareasManager _tareaManage { get; private set; }

        public FacadeTareaAdmin(SqlContext context)
        {
            ProyectoServices = new(context);
            _tareaManager = new(context, context);
            _usuarioManager = new(context, context);
            _tareaManage = new(context);

        }
        public List<Proyectos> GetAllProyect()
        {
            return ProyectoServices.GetAll();
        }
       /* public DetallesDto DetalleTarea(int id)
        {
            return _tareaManager.Detalles(id);
        }*/
        public void CrearTarea(TareaDto tarea)
        {
            _tareaManager.CrearTarea(tarea);
        }
        public List<Tarea> GetByProyectoId(int proyectoId)
        {
            return _tareaManager?.GetByProyectoId(proyectoId)!;
        }
       
        public List<UserDto> GetAllUser()
        {
            return _usuarioManager.GetAllUserDto();
        }
        public void BorrarTarea(int id)
        {
            _tareaManager.BorrarTarea(id);
        }

    }
}
