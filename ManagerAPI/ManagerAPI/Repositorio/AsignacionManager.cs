using ManagerAPI.Interfaces;
using ManagerAPI.Model;
using Newtonsoft.Json;

namespace ManagerAPI.Repositorio
{
    public class AsignacionManager : IRepository<AsignacionTarea>, ICrud<AsignacionTarea>
    {
        private readonly string? _pathJson;
        private List<AsignacionTarea> _asignaciones;

        public AsignacionManager(string pathJson)
        {
            _pathJson = pathJson;
            _asignaciones = CargarDatos();
        }

        public AsignacionTarea Actualizar(int id, AsignacionTarea data)
        {
            if(data != null && id != null)
            {
                var datos = BuscarPorId(id);
                _asignaciones.Remove(data);
                _asignaciones.Add(data);
                GuardarDatos();
                return data;
            }
            return null!;
        }

        public List<AsignacionTarea> CargarDatos()
        {
            if (!File.Exists(_pathJson))
            {
                return [];
            }

            var json = File.ReadAllText(_pathJson);
            return JsonConvert.DeserializeObject<List<AsignacionTarea>>(json) ?? [];
        }

        public void Delete(int id)
        {
           if(id != null)
            {
                var data = BuscarPorId(id);
                _asignaciones.Remove(data);
            }
        }

        public List<AsignacionTarea> GetAll()
        {
            return _asignaciones;
        }

        public AsignacionTarea Guardar(AsignacionTarea Data)
        {
            if(Data != null)
            {
                _asignaciones.Add(Data);
                GuardarDatos();
                return Data;
            }
            return null!;
        }
        public List<AsignacionTarea> Guardar(List<AsignacionTarea> Data)
        {
            if (Data != null)
            {
                foreach(var asignacion in Data)
                {
                    _asignaciones.Add(asignacion);
                }
                GuardarDatos();
                return Data;
            }
            return null!;
        }

        public void GuardarDatos()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_asignaciones, Formatting.Indented);
                File.WriteAllText(_pathJson!, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public AsignacionTarea BuscarPorId(int id)
        {
            return _asignaciones.FirstOrDefault(asign => asign.Id == id)!;
        }
        public AsignacionTarea BuscarPorTarea(int id)
        {
            return _asignaciones.FirstOrDefault(asign => asign.TareaId == id)!;
        }
    }
}
