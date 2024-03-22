using ManagerAPI.Core.Entities;

namespace ManagerApi.Core.Interface
{
    public interface IHomeworkService
    {
        Task<bool> Delete(int id);
        IEnumerable<Tarea> GetAll();
        Task<Tarea> GetById(int id);
        Task<Tarea> Insert(Tarea entity);
        Task<bool> Update(Tarea entity);
    }
}