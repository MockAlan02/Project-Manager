using ManagerApi.Core.Entities;

namespace ManagerApi.Core.Interface
{
    public interface IProyectoService
    {
        IEnumerable<Proyecto> GetAll();
    }
}