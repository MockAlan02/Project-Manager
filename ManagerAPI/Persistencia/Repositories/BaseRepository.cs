using ManagerApi.Core.Entities;
using ManagerApi.Core.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Persistencia.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntities
    {
        private readonly ProjectManagerContext _context;
        private protected readonly DbSet<T> _entities;
        
        public BaseRepository(ProjectManagerContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
       
        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FirstAsync(e => e.Id == id);
        }

       public async Task Delete(int id)
        {
            var entity =  await _entities.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }

        public async Task Insert(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}