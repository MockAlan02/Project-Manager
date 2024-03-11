using ManagerAPI.Model;
using ManagerAPI.Repositorio;
using Persistencia.Context;
using Persistencia.Dto;

namespace ManagerAPI.Services
{
    public class UsuarioService
    {
        private readonly UsuarioManager _usuarioService;
        private readonly AsignacionTareaServices _asignacionTareaServices;

        public UsuarioService(ProjectManagerContext usercontext, ProjectManagerContext asignContext)
        {
            _usuarioService = new(usercontext);
            _asignacionTareaServices = new(asignContext);
        }

        public void CrearUsuario(Usuario usuario)
        {
            _usuarioService.Insert(usuario);
            
        }
        public void BorrarUsuario(int id)
        {
            _usuarioService.Delete(id);
        }
        public void ActualizarUsuario(int id, Usuario user)
        {
            _usuarioService.Update(id, user);
        }
        public List<UserDto> GetAll()
        {
            return _usuarioService.GetAllUserDto();
        }

        public List<UserDto> GetAllUserDto()
        {
            return _usuarioService.GetAllUserDto();
        }
        public Usuario BuscarPorId(int id)
        {
            return _usuarioService.GetById(id);
        }

    }
}
