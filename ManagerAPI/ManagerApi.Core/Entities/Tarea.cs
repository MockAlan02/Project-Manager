using System.Text.Json.Serialization;

namespace ManagerApi.Core.Entities;

public partial class Tarea : BaseEntities
{
    public Tarea()
    {
        AsignacionUsuarios = new HashSet<AsignacionUsuario>();
    }

    public int ProyectoId { get; set; }

    public string? Detalles { get; set; }

    public bool Estado { get; set; }

    public DateTime? ExpireTime { get; set; }
    [JsonIgnore]
    public virtual ICollection<AsignacionUsuario>? AsignacionUsuarios { get; set; } = [];
    [JsonIgnore]
    public virtual Proyecto? Proyecto { get; set; } = null!;
}
