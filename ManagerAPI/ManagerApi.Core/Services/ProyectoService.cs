using ManagerApi.Core.Entities;
using ManagerApi.Core.Interface;

namespace ManagerApi.Core.Services
{
    public class ProyectoService : IProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProyectoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Proyecto> GetAll()
        {
            return _unitOfWork.ProyectoService.GetAll();
        }
    }
}
