using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Model
{
    public class UsuarioDetail
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        private int _edad;
        public DateTime FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
        public int Edad
        {
            get
            {
                if (this._edad <= 0)
                {
                    this._edad = new DateTime(DateTime.Now.Subtract(this.FechaNacimiento).Ticks).Year - 1;
                }
                return this._edad;
            }
        }
    }
}
