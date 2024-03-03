using ManagerAPI.Model;
using ManagerAPI.Repositorio;

namespace ManagerAPI.Services
{
    public class UsuarioService
    {
        private readonly UsuarioManager _usuarioService;
        private readonly AsignacionTareaServices _asignacionTareaServices;

        public UsuarioService(string pathJson, string pathAsignacion)
        {
            _usuarioService = new(pathJson);
            _asignacionTareaServices = new(pathAsignacion);
        }

        public Usuario IniciarSesion(string correo, string contrasena) 
        {
           
            return _usuarioService.IniciarSesion(correo, contrasena);
        }

        public Usuario CrearUsuario(Usuario usuario)
        {
            _asignacionTareaServices.CrearAsignacion(usuario.AsignacionesTareas!);
            return _usuarioService.Guardar(usuario);
        }
        public void BorrarUsuario(int id)
        {
            _usuarioService.Delete(id);
        }
        public void ActualizarUsuario(int id, Usuario user)
        {
            _usuarioService.Actualizar(id, user);
        }
        public List<Usuario> GetAll()
        {
            return _usuarioService.GetAll();
        }
        public Usuario BuscarPorId(int id)
        {
            return _usuarioService.BuscarPorId(id);
        }

    }
}
