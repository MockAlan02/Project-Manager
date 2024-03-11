using ManagerAPI;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerAPI.Model
{
    public class AsignacionTarea
    {
            [Key]
            public int Id { get; set; }
            [ForeignKey("IdUsuario")]
            public int IdUsuario { get; set; }
            [ForeignKey("IdTarea")]
            public int IdTarea { get; set;}
            
    }
}
