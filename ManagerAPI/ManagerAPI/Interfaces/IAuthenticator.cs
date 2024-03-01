namespace ManagerAPI.Interfaces
{
    public interface IAuthenticator<T>
    {
        public T IniciarSesion(string username, string password);
        public void CerrarSesion();
    }
}
