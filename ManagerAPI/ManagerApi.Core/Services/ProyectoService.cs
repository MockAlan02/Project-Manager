using ManagerApi.Core.Interface;
using ManagerAPI.Core.Entities;
using ManagerAPI.Core.Interface;

namespace ManagerApi.Core.Services
{
    public class ProyectoService : IProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProyectoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Proyectos> GetAll()
        {
            return _unitOfWork.ProyectoService.GetAll();
        }
    }
}
