using ManagerApi.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Core.Entities
{
    public class Proyectos : BaseEntities
    {
        public string? Nombre { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

}
