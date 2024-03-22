using ManagerAPI.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql.Internal;
using Persistencia.Context;
using Persistencia.Dto;
using Persistencia.Interfaz;
using System.Runtime.InteropServices;


namespace ManagerAPI.Repositorio
{
    public enum Respuesta { 
    Ok, Bad
    }
    public class UsuarioManager : IRepository<Usuario> 
    {
        private readonly ProjectManagerContext _project;
        public UsuarioManager(ProjectManagerContext project)
        {
                _project = project;
        }

        public void CerrarSesion()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var usuario = GetById(id);
            var userDetail = _project.UsuarioDetalle.FirstOrDefault(userDetail => userDetail.Id == usuario.IdUsuarioDetalles);
            _project.UsuarioDetalle.Remove(userDetail!);
            _project.Usuario.Remove(usuario);
            _project.SaveChanges();

        }
     
        public List<UserDto> GetAllUserDto()
        {
        
            var usuariosConDetalle = (from usuario in _project.Usuario
                                      join detalle in _project.UsuarioDetalle on usuario.IdUsuarioDetalles equals detalle.Id
                                      select new UserDto
                                      {
                                          UserId = usuario.Id,
                                          Nombre = detalle.Nombre
                                          
                                      }).ToList();

            return usuariosConDetalle;
        }

        public Usuario GetById(int id)
        {
            return _project.Usuario.FirstOrDefault(user => user.Id == id)!;
        }

        public void Insert(Usuario entity)
        {
            _project.Usuario.Add(entity);
            _project.SaveChanges();
        }

        public void Update(int id, Usuario newData)
        {
           if(newData != null)
            {
                var user = GetById(id);
                _project.Entry(user).CurrentValues.SetValues(newData);
                _project.SaveChanges();
            }
        }

        public List<Usuario> GetAll()
        {
            return _project.Usuario.ToList();
        }
    }
}
