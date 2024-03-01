using ManagerAPI.Interfaces;
using ManagerAPI.Model;
using Newtonsoft.Json;

namespace ManagerAPI.Repositorio
{
    public class TareasManager : IRepository<Tarea>, ICrud<Tarea>
    {
        private string _pathLog;
        private List<Tarea> _tareas;

        public TareasManager(string pathJson) {
            _pathLog = pathJson;
            _tareas = CargarDatos();
        }

     

        public Tarea BuscarPorId(int Id)
        {
           return _tareas.FirstOrDefault(ta => ta.Id == Id)!;
        }

        
        public Tarea Guardar(Tarea Data)
        {
            if (Data != null)
            {
                _tareas.Remove(Data);
                _tareas.Add(Data);
                GuardarDatos();
                return Data;
            }

            return null!;

        }

        public void GuardarDatos()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_tareas, Formatting.Indented);
                File.WriteAllText(_pathLog, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Tarea> CargarDatos()
        {
            if (!File.Exists(_pathLog))
            {
                return [];
            }

            var json = File.ReadAllText(_pathLog);
            return JsonConvert.DeserializeObject<List<Tarea>>(json) ?? [];
        }

        public List<Tarea> GetAll()
        {
            return _tareas;
        }

        public Tarea Actualizar(int id, Tarea data)
        {
           if(id != null && data != null)
            {
                var task = BuscarPorId(id);
                _tareas.Remove(task);
                _tareas.Add(data);
                GuardarDatos();
                return data;
            }
            return null!;
        }

        public void Delete(int id)
        {
            if(id  != null)
            {
                var task = BuscarPorId(id);
                _tareas.Remove(task);
            }
        }
    }
}
