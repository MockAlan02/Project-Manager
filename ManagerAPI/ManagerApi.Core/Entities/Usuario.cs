namespace ManagerApi.Core.Entities;

public partial class Usuario : BaseEntities
{

    public int IdUsuarioDetalles { get; set; }

    public string? Correo { get; set; }

    public string? Contrasena { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<AsignacionUsuario> AsignacionUsuarios { get; set; } = new List<AsignacionUsuario>();

    public virtual UsuarioDetalle IdUsuarioDetallesNavigation { get; set; } = null!;
}
