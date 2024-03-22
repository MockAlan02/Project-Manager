using ManagerApi.Core.Interface;
using ManagerAPI.Core.Entities;

namespace ManagerAPI.Core.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Tarea> HomeworkService { get; }
        IRepository<Proyectos> ProyectoService{ get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
