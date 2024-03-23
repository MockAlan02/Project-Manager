using ManagerApi.Core.Dto;
using ManagerApi.Core.Entities;
using ManagerAPI.Core.Dto;

namespace ManagerApi.Core.Interface
{
    public interface IHomeworkService
    {
        Task<bool> Delete(int id);
        IEnumerable<Tarea> GetAll();
        Task<Tarea> GetById(int id);
        Task<TareaDto> Insert(TareaDto entity);
        Task<bool> Update(Tarea entity);
        Task<IEnumerable<Tarea>> GetByProjectId(int id);
        Task<DetallesDto> TareaDetail(int id);
    }
}