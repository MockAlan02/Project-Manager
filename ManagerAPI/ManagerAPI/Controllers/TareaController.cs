using ManagerAPI.Dto;
using ManagerAPI.Model;
using ManagerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController:ControllerBase
    {
        private readonly TareaServices? _tareaServices;
        public TareaController()
        {
            _tareaServices = new("./Json/Tareas.json", "./Json/AsignacionTarea.json");
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_tareaServices!.GetAll());
        }

        [HttpGet("id")]
        public ActionResult GetId(int id) {
            var data = _tareaServices?.GetById(id);  
            if(data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
        [HttpGet("Detalles")]
        public ActionResult GetDetalles(int id)
        {
            var detalles = _tareaServices?.Detalles(id);
            if(detalles != null)
                return Ok(detalles);
            return BadRequest();
        }
        [HttpGet("ProyectoId")]
        public ActionResult GetProyectoId(int id)
        {
            var tareas = _tareaServices?.GetByProyectoId(id);
            if (tareas != null)
                return Ok(tareas);
            return BadRequest();
        }
        [HttpPost]
        public ActionResult Post(Tarea tarea)
        {
            if(tarea == null)
            {
                return BadRequest();
            }
            return Ok(_tareaServices!.CrearTarea(tarea));
        }
        [HttpPost("Crear")]
        public ActionResult PostTarea(TareaDto tarea)
        {
            if (tarea == null)
            {
                return BadRequest();
            }
            return Ok(_tareaServices!.CrearTarea(tarea));
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut]
        public ActionResult Put(int id, Tarea tarea)
        {
            if(tarea == null)
            {
                return BadRequest();
            }
            return Ok(_tareaServices!.ActualizarTarea(id,tarea));
        }
    }
}
