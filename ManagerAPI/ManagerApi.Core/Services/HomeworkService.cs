using ManagerApi.Core.Entities;
using ManagerApi.Core.Interface;


namespace ManagerApi.Core.Interface
{
    public class HomeworkService : IHomeworkService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeworkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.HomeworkService.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Tarea> GetAll()
        {
            return _unitOfWork.HomeworkService.GetAll();
        }

        public async Task<Tarea> GetById(int id)
        {
            return await _unitOfWork.HomeworkService.GetById(id);
        }

        public async Task<Tarea> Insert(Tarea entity)
        {
            await _unitOfWork.HomeworkService.Insert(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Update(Tarea entity)
        {
            _unitOfWork.HomeworkService.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
