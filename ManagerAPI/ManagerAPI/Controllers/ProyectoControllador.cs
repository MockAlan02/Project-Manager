using ManagerAPI.Model;
using ManagerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectoController: ControllerBase
    {
        private readonly ProyectoServices? _proyectoService;
        public ProyectoController()
        {
            _proyectoService = new("./Json/Proyectos.json");
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_proyectoService.GetAll());
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
            return Ok(_proyectoService.CrearProyecto(proyecto));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            _proyectoService?.EliminarProyecto(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int id, Proyectos proyecto)
        {
            if(id == null && proyecto == null)
            {
                return BadRequest();
            }
            return Ok(_proyectoService?.ActualizarProyecto(id,proyecto));
        }
    }
}
