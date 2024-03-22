using ManagerApi.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerAPI.Core.Entities
{
   
    public class Usuario : BaseEntities
    {
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public int IdUsuarioDetalles{ get; set; }
        public string? Rol { get; set; }
    }
}