using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerAPI.Model
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProyectoId")]
        public int? ProyectoId { get; set; }
        public string? Detalles { get; set; }
        public bool Estado { get; set; }
        public DateTime ExpireTime { get; set; }
    }

}
