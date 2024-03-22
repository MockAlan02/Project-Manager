using ManagerAPI.Facade;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Persistencia.Context;

namespace ManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacadeController:ControllerBase
    {
        private readonly Interfaces.ILogger logger;
        private readonly FacadeTareaAdmin? _facade;
        public FacadeController(SqlContext context)
        {
            logger = new Logger.Logger("./Texto/AutoSaving.txt");
            //string pathUserJson, string pathProyectoJson, string pathTareaManager, string asignacionPath
            _facade = new(context);
        }

        [HttpGet]
        public ActionResult GetAllUser()
        {
            var _tareas = _facade?.GetAllUser);
            if(_tareas != null)
            {
                return Ok(_tareas);

            }
                return BadRequest();
         
        }
     
        [HttpGet("Proyectos")]
        public ActionResult GetProyectos()
        {
            var proyectos = _facade?.GetAllProyect();
            if(proyectos == null)
            {
                return NoContent();
            }
            return Ok(proyectos);
        }


        [HttpGet("TareaId")]
        public ActionResult TareaById(int id)
        {
            var tarea = _facade?._tareaManage.GetById(id);
            if(tarea == null)
            {
                return NotFound();
            }
            return Ok(tarea);
        }

        [HttpGet("ProyectoId")]
        public ActionResult GetProyectById(int id)
        {
            var proyect = _facade?.GetByProyectoId(id);
            if(proyect == null)
            {
                return NotFound();
            }
            return Ok(proyect);
        }

       [HttpGet("Detalles")]
        public ActionResult GetDetalles(int id)
        {
            var detalles = _facade?._tareaManage.DetallesDto(id);
            if(detalles == null)
            {
                return NotFound(); 
            }
            return Ok(detalles);
        }
        //
        [HttpPost("Crear")]
        public ActionResult PostTarea(TareaDto tarea)
        {
            if (tarea == null)
            {
                return BadRequest();
            }
            _facade.CrearTarea(tarea);
            var usersJsonString = JsonConvert.SerializeObject(tarea);
            logger.Info(usersJsonString);
            return Ok();
        }
        //Url Para eliminar Tareas
        [HttpDelete("BorrarTarea")]
        public ActionResult Delete(int id)
        {
            if(id == null)
            {
                return BadRequest();
            }
           
            _facade.BorrarTarea(id);
            logger.Info("se borro el id" + id.ToString()!);
            return Ok();
        }
    }
}
