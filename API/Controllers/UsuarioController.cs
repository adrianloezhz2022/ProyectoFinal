using Microsoft.AspNetCore.Mvc;
using API.Model;
using API.ADO_Repository;
using API.Controllers.DTOS;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> GetUsuarios()
        {
            return UsuarioHandler.GetUsarios();
        }
        [HttpDelete]
        public bool EliminarUsuario([FromBody] int id)
        {
            return UsuarioHandler.EliminarUsuario(id);
        }
        [HttpPost]
        public bool CrearUsuario([FromBody] PostUsuario usuario)
        {
            return UsuarioHandler.CrearUsuario(new Usuario {
                
                Apellido = usuario.Apellido,
                Contraseña = usuario.Contraseña,
                Mail = usuario.Mail,
                Nombre = usuario.Nombre,
                NombreUsuario = usuario.NombreUsuario});
        }
        [HttpPut]
        public bool ModificarUsuario([FromBody] PutUsuario usuario)
        {
            return UsuarioHandler.ModificarUsuario(new Usuario {
                Id = usuario.Id,Apellido = usuario.Apellido,Contraseña = usuario.Contraseña,Mail = usuario.Mail,Nombre = usuario.Nombre,NombreUsuario = usuario.NombreUsuario});
        }
    }
} 