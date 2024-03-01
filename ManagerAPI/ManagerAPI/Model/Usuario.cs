namespace ManagerAPI.Model
{
   
    public class Usuario
    {
        public int Id { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public UsuarioDetail? UserDetail{ get; set; }
        public string? Rol { get; set; }
        public List<AsignacionTarea>? AsignacionesTareas { get; set; } = null;
    }
}