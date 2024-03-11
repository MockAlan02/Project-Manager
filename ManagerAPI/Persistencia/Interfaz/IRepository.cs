namespace Persistencia.Interfaz
{
    internal interface IRepository<T>
    {
        public List<T> GetAll();
        public T GetById(int id);
        public void Delete(int id);
        public void Insert(T entity);
        public void Update(int id, T newData);
    }
}
