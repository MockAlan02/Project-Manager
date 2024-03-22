using ManagerApi.Core.Entities;

namespace ManagerApi.Core.Interface
{
    public interface IRepository<T> where T : BaseEntities
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Delete(int id);
        public void Insert(T entity);
        public void Update(int id, T newData);
    }
}
