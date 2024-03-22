using ManagerApi.Core.Entities;
using ManagerApi.Core.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;

namespace Persistencia.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntities
    {
        private readonly ProjectManagerContext _context;
        private readonly DbSet<T> _entities;
        public BaseRepository()
        {
            
        }
        public void Delete(int id)
        {
           var entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, T newData)
        {
            throw new NotImplementedException();
        }
    }
}