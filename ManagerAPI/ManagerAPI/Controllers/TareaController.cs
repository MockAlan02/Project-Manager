using ManagerApi.Core.Entities;
using ManagerApi.Core.Interface;
using ManagerAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class TareaController:ControllerBase
    {
        private readonly IHomeworkService _homeworkService;
        public TareaController(IHomeworkService homeworkService)
        {
          _homeworkService = homeworkService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var homeworks = _homeworkService.GetAll();
            var response = new ApiResponse<IEnumerable<Tarea>>(homeworks);
            return Ok(response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetId(int id) {
            var homework = await _homeworkService.GetById(id);
            var response = new ApiResponse<Tarea>(homework);
            return Ok(response);
        }
     
    }
}
