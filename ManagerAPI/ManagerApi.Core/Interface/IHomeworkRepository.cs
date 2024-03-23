using ManagerApi.Core.Entities;

namespace ManagerApi.Core.Interface
{
    public interface IHomeworkRepository : IRepository<Tarea>
    {
        IEnumerable<Tarea> GetByProyectoId(int id);
    }
}