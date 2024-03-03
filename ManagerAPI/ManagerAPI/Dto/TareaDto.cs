namespace ManagerAPI.Dto
{
    public class TareaDto
    {
        public int ProyectoId { get; set; }
        public string Detalles { get; set; }
        public bool Estado { get; set; }
        public DateTime ExpireTime { get; set; }
        public int PersonaId { get; set; }
    }
}
