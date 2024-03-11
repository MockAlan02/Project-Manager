using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerAPI.Model
{
   
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        [ForeignKey("IdUsuarioDetalles")]
        public int IdUsuarioDetalles{ get; set; }
        public string? Rol { get; set; }
        
    }
}