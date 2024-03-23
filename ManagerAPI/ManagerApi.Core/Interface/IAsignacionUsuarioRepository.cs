using ManagerApi.Core.Entities;

namespace ManagerApi.Core.Interface
{
    public interface IAsignacionUsuarioRepository : IRepository<AsignacionUsuario>
    {
        Task DeleteByTareaId(int id);
        Task<AsignacionUsuario> GetByTareaId(int id);
    }
}