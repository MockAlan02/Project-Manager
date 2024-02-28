namespace ManagerAPI.Model
{
    public class Tarea
    {
        public Proyectos? ProyectoDetalles { get; set; }
        public bool Estado { get; set; }
        public DateTime ExpireTime { get; set; }
    }

}
