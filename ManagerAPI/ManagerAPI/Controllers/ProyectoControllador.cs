using ManagerApi.Core.Entities;
using ManagerApi.Core.Interface;
using ManagerAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class ProyectoController: ControllerBase
    {
        private readonly IProyectoService _proyectoService;
        public ProyectoController(IProyectoService proyectoService)
        {
          _proyectoService = proyectoService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           var proyectos =  _proyectoService.GetAll();
           var response = new ApiResponse<IEnumerable<Proyecto>>(proyectos);
           return Ok(response);
        }
      
    }
}
