using ManagerAPI.Interfaces;
using ManagerAPI.Model;
using Newtonsoft.Json;

namespace ManagerAPI.Repositorio
{
    public enum Respuesta { 
    Ok, Bad
    }
    public class UsuarioManager : IRepository<Usuario> , IAuthenticator<Usuario>
    {
        private string _pathLog;
        private List<Usuario> _usuarios;
        public UsuarioManager(string pathLog)
        {
            _pathLog = pathLog;
            _usuarios = CargarDatos();

        }
        public Usuario BuscarPorId(int Id)
        {
            return _usuarios.FirstOrDefault(us => us.Id == Id)!;
        }

        public List<Usuario> CargarDatos()
        {
            if (!File.Exists(_pathLog))
            {
                return [];
            }

            var json = File.ReadAllText(_pathLog);
            return JsonConvert.DeserializeObject<List<Usuario>>(json) ?? [];
        }

        public void CerrarSesion()
        {
            throw new NotImplementedException();
        }

        public Usuario Guardar(Usuario Data)
        {
            var user = Data;

            _usuarios.Add(Data);
            if(_usuarios.Exists(users => users.Id == user.Id))
            {
                _usuarios.Remove(user);
            }
            _usuarios.Add(user);
            GuardarDatos();
            return Data;
        }

        public void GuardarDatos()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_usuarios, Formatting.Indented);
                File.WriteAllText(_pathLog, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(int id)
        {
            var user = BuscarPorId(id);
            _usuarios.Remove(user!);
            GuardarDatos();

        }
        public void Actualizar(int id, Usuario Usuario)
        {
            var user = BuscarPorId(id);
            _usuarios.Remove(user);
            _usuarios.Add(Usuario);
            GuardarDatos();
        }

        public Usuario IniciarSesion(string username, string password)
        {
           var user =  _usuarios.FirstOrDefault(user => user.Correo == username && user.Contrasena == password);
            return user!;
        }
        public List<Usuario> GetAll()
        {
            return _usuarios;
        }
    }
}
