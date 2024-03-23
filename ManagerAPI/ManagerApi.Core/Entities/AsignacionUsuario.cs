namespace ManagerApi.Core.Entities;

public partial class AsignacionUsuario : BaseEntities
{

    public int IdUsuario { get; set; }

    public int IdTarea { get; set; }

    public virtual Tarea IdTareaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
