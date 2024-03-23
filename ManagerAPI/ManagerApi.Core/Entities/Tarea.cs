namespace ManagerApi.Core.Entities;

public partial class Tarea : BaseEntities
{

    public int ProyectoId { get; set; }

    public string? Detalles { get; set; }

    public bool Estado { get; set; }

    public DateTime? ExpireTime { get; set; }

    public virtual ICollection<AsignacionUsuario> AsignacionUsuarios { get; set; } = new List<AsignacionUsuario>();

    public virtual Proyecto Proyecto { get; set; } = null!;
}
