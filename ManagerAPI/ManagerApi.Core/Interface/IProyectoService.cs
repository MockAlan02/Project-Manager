using ManagerAPI.Core.Entities;

namespace ManagerApi.Core.Interface
{
    public interface IProyectoService
    {
        IEnumerable<Proyectos> GetAll();
    }
}