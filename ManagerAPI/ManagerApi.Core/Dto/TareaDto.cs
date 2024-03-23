namespace ManagerApi.Core.Dto
{
    public class TareaDto
    {
        public int IdUser { get; set; }
        public int IdProyecto { get; set; }
        public string Detalles { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
