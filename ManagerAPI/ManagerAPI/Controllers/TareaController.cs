using ManagerAPI.Dto;
using ManagerAPI.Model;
using ManagerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Persistencia.Context;

namespace ManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class TareaController:ControllerBase
    {
        private readonly TareaServices? _tareaServices;
        private readonly Interfaces.ILogger logger;
        public TareaController(SqlContext context)
        {
            _tareaServices = new(context, context);
            logger = new Logger.Logger("./Texto/AutoSaving.txt");
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
      /*  [HttpGet("Detalles")]
        public ActionResult GetDetalles(int id)
        {
            var detalles = _tareaServices?.Detalles(id);
            if(detalles != null)
                return Ok(detalles);
            return BadRequest();
        }*/
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
            logger.Info("Se creo la tarea la info es : " + tarea.ToString()!);
            _tareaServices!.CrearTarea(tarea);
            return Ok();
        }
        [HttpPost("Crear")]
        public ActionResult PostTarea(TareaDto tarea)
        {
            if (tarea == null)
            {
                return BadRequest();
            }
            var tareaString = JsonConvert.SerializeObject(tarea);
            logger.Info("se creo la tarea de tarea " + tareaString);
            return Ok(_tareaServices!.CrearTarea(tarea));
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            logger.Info("se elimino el proyecto de id : " + id);
            _tareaServices?.BorrarTarea(id);
            return Ok();
        }
        [HttpPut]
        public ActionResult Put(int id, Tarea tarea)
        {
            if(tarea == null)
            {
                return BadRequest();
            }
            var tareastring = JsonConvert.SerializeObject(tarea);
            logger.Info("Se actualizo el proyecto de id " + id + " la info es: " + tareastring);
            _tareaServices!.ActualizarTarea(id, tarea);
            return Ok();
        }
    }
}
