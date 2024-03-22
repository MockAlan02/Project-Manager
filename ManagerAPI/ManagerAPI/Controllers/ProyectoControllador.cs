using ManagerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Persistencia.Context;

namespace ManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProyectoController: ControllerBase
    {
        private readonly ProyectoServices? _proyectoService;
        private readonly Interfaces.ILogger logger;
        public ProyectoController(SqlContext context)
        {
            _proyectoService = new(context);
            logger = new Logger.Logger("./Texto/AutoSaving.txt");
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_proyectoService?.GetAll()); 
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }
        [HttpPost]
        public ActionResult Post(Proyectos proyecto)
        {
            if(proyecto == null)
            {
                return BadRequest();
            }

            var proyectostring = JsonConvert.SerializeObject(proyecto);
            logger.Info("Se creo el proyecto:  " + proyectostring);
            _proyectoService?.CrearProyecto(proyecto);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            logger.Info("Se elimino el proyecto de id : " + id);
            _proyectoService?.EliminarProyecto(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int id, Proyectos proyecto)
        {
            if (id == null && proyecto == null)
            {
                return BadRequest();
            }
            var proyectString = JsonConvert.SerializeObject(proyecto);
            logger.Info("Se actualizo el proyecto de id " + id + "La nueva info es " + proyectString);
            _proyectoService?.ActualizarProyecto(id, proyecto);
            return Ok();
        }
    }
}
