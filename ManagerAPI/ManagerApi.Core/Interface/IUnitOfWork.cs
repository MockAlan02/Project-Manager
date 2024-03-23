using ManagerApi.Core.Entities;
namespace ManagerApi.Core.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Tarea> HomeworkService { get; }
        IRepository<Proyecto> ProyectoService{ get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
