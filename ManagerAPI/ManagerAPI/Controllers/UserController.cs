﻿using ManagerAPI.Interfaces;
using ManagerAPI.Model;
using ManagerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace ManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService usuarioService;

        public UsuarioController()
        {
            usuarioService = new("./Json/Usuarios.json","./Json/AsignacionTarea.json");
        }
        [HttpGet]
        public ActionResult IniciarSesion(string correo, string contrasena)
        {
            var user = usuarioService.IniciarSesion(correo, contrasena);
            if(user != null)
            {
                return Ok(user);
            }
            return BadRequest();
        }
        [HttpPost]
        public ActionResult CrearUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
              
                return Ok(usuarioService.CrearUsuario(usuario));
            }
            return BadRequest();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id != null)
            {
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
                usuarioService.ActualizarUsuario(id, usuario);
                return Ok();
            }
            return BadRequest();
        }
    }
}
