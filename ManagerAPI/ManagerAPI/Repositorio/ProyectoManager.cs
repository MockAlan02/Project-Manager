using ManagerAPI.Interfaces;
using ManagerAPI.Model;
using Newtonsoft.Json;

namespace ManagerAPI.Repositorio
{
    public class ProyectoManager : IRepository<Proyectos>, ICrud<Proyectos>
    {
        private string _pathLog;
        private List<Proyectos> _proyectos;
        public ProyectoManager(string pathLog)
        {
            _pathLog = pathLog;
            _proyectos = CargarDatos();

        }

        public Proyectos BuscarPorId(int Id)
        {
            return _proyectos.FirstOrDefault(pro => pro.Id == Id)!;
        }


        public Proyectos Guardar(Proyectos Data)
        {
            if(_proyectos.Exists(pro => pro.Id == Data.Id))
            {
                _proyectos.Remove(Data);
            }
            _proyectos.Add(Data);
            GuardarDatos();
            return Data;
        }

        public void GuardarDatos()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_proyectos, Formatting.Indented);
                File.WriteAllText(_pathLog, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Proyectos> CargarDatos()
        {
            if (!File.Exists(_pathLog))
            {
                return [];
            }

            var json = File.ReadAllText(_pathLog);
            return JsonConvert.DeserializeObject<List<Proyectos>>(json) ?? [];
        }

        public Proyectos Actualizar(int id, Proyectos data)
        {
            if(id != null && data != null)
            {
            var pro = BuscarPorId(id);
                _proyectos.Remove(pro);
                _proyectos.Add(data);
                GuardarDatos();
                return data;
            }
            return null!;

        }

        public void Delete(int id)
        {
            var data = BuscarPorId(id);
            if (data != null)
            {
                _proyectos.Remove(data);
                GuardarDatos();
            }
        }

        public List<Proyectos> GetAll()
        {
            return _proyectos;
        }
    }
}
