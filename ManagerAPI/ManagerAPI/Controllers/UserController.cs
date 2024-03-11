using ManagerAPI.Interfaces;
using ManagerAPI.Model;
using ManagerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Persistencia.Context;
using System.Diagnostics.Contracts;

namespace ManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService usuarioService;
        private readonly Interfaces.ILogger logger;

        public UsuarioController(SqlContext context)
        {
            usuarioService = new(context, context);
            logger = new Logger.Logger("./Texto/AutoSaving.txt");
        }
        [HttpGet("All")]
        public ActionResult GetAll()
        {
            var users = usuarioService.GetAll();
            if (User == null)
            {
                return null!;
            }
            return Ok(users);
                }
      /*  [HttpGet]
        public ActionResult IniciarSesion(string correo, string contrasena)
        {
            var user = usuarioService.IniciarSesion(correo, contrasena);
            if(user != null)
            {
                return Ok(user);
            }
            return BadRequest();
        }*/
        [HttpPost]
        public ActionResult CrearUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                var userString = JsonConvert.SerializeObject(usuario);
                logger.Info(" se creo el usuario su info es  " + userString);
                usuarioService.CrearUsuario(usuario);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id != null)
            {
                logger.Info("Se elimino el usuario de id " + id);
                usuarioService.BorrarUsuario(id);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public ActionResult ActualizarUsuario(int id, Usuario usuario)
        {
            if(id != null && usuario != null)
            {
                var usuarioString = JsonConvert.SerializeObject(usuario);
                logger.Info("se actualizo el usuario de id " + id + " la info nueva del usuario es " + usuarioString);
                usuarioService.ActualizarUsuario(id, usuario);
                return Ok();
            }
            return BadRequest();
        }
    }
}
