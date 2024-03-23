namespace ManagerApi.Core.Entities;

public partial class Proyecto : BaseEntities
{

    public string? Nombre { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
