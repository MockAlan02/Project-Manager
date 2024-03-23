using ManagerApi.Core.Entities;
namespace ManagerApi.Core.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IHomeworkRepository HomeworkService { get; }
        IRepository<Proyecto> ProyectoService{ get; }
        IRepository<Usuario> UsuarioService{ get; }
        IRepository<UsuarioDetalle> UsuarioDetailService { get; }
        IAsignacionUsuarioRepository AsignacionRepo { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
