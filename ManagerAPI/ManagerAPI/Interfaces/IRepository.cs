namespace ManagerAPI.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> CargarDatos();
        public void GuardarDatos();
        public T Guardar(T Data);
      
    }
}
