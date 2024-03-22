using ManagerApi.Core.Entities;

namespace ManagerApi.Core.Interface
{
    public interface IRepository<T> where T : BaseEntities
    {
        public IEnumerable<T> GetAll();
        public Task<T> GetById(int id);
        public Task Delete(int id);
        public Task Insert(T entity);
        public void Update(T entity);
    }
}
