using ManagerApi.Core.Dto;
using ManagerApi.Core.Entities;
using ManagerAPI.Core.Dto;


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
            await _unitOfWork.AsignacionRepo.DeleteByTareaId(id);
            await _unitOfWork.SaveChangesAsync();
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

        public async Task<TareaDto> Insert(TareaDto entity)
        {
            var tarea = new Tarea
            {
                Detalles = entity.Detalles,
                Estado = entity.Estado,
                ProyectoId = entity.IdProyecto,
                ExpireTime = entity.ExpireTime
            };

            await _unitOfWork.HomeworkService.Insert(tarea);
             _unitOfWork.SaveChanges();

            var asignacion = new AsignacionUsuario
            {
                IdTarea = tarea.Id,
                IdUsuario = entity.IdUser
            };
            _unitOfWork?.AsignacionRepo.Insert(asignacion);
            _unitOfWork?.SaveChanges();
            return entity;
        }

        public async Task<bool> Update(Tarea entity)
        {
            _unitOfWork.HomeworkService.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Tarea>> GetByProjectId(int id)
        {
            var tarea = _unitOfWork.HomeworkService.GetByProyectoId(id);
            return tarea;
        }

        public async Task<DetallesDto> TareaDetail(int id)
        {
            var tarea = await _unitOfWork.HomeworkService.GetById(id);
            var asigancion = await _unitOfWork.AsignacionRepo.GetByTareaId(tarea.Id);
            var user = await _unitOfWork.UsuarioService.GetById(asigancion.IdTarea);
            var userDetail = await _unitOfWork.UsuarioDetailService.GetById(user.IdUsuarioDetalles);
            
            return new DetallesDto
            {
                Detalles = tarea.Detalles,
                Estado = tarea.Estado,
                ExpireTime = (DateTime)tarea.ExpireTime!,
                Nombre = userDetail.Nombre
            };
        }
    }
}
