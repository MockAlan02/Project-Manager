namespace ManagerApi.Core.Entities;

public partial class UsuarioDetalle : BaseEntities
{

    public string? Nombre { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Direccion { get; set; }

    public int? Edad { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
