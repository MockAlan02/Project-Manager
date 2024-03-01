namespace ManagerAPI.Interfaces
{
    public interface ICrud<T>
    {
        public List<T> GetAll();
        public T Actualizar(int id, T data);
        public void Delete(int id);
    }
}
