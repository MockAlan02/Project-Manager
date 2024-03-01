namespace ManagerAPI.Model
{
    public class Tarea
    {
        public int Id { get; set; }
        public int? ProyectoId { get; set; }
        public string? Detalles { get; set; }
        public bool Estado { get; set; }
        public DateTime ExpireTime { get; set; }
    }

}
