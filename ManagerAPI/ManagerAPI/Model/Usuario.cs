namespace ManagerAPI.Model
{
    public enum UserRol
    {
        Admin, 
        Regular
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public UsuarioDetail? UserDetail{ get; set; }
        public UserRol? Rol { get; set; }
        public List<Tarea>? Tareas { get; set; }
    }

}
