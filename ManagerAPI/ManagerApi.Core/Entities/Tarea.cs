using ManagerApi.Core.Entities;

namespace ManagerAPI.Core.Entities
{
    public class Tarea : BaseEntities
    {
        public int? ProyectoId { get; set; }
        public string? Detalles { get; set; }
        public bool Estado { get; set; }
        public DateTime ExpireTime { get; set; }
    }

}
