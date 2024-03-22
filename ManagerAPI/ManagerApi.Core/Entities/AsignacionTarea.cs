using ManagerApi.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerAPI.Core.Entities
{
    public class AsignacionTarea : BaseEntities
    {
            [ForeignKey("IdUsuario")]
            public int IdUsuario { get; set; }
            [ForeignKey("IdTarea")]
            public int IdTarea { get; set;}
            
    }
}
