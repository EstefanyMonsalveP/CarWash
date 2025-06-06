using Servicios_lavadero.Clases;
using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicios_lavadero.Controllers
{
    [EnableCors(origins: "https://localhost:44315", headers: "*", methods: "*")]
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("CrearUsuario")]
        public string CrearUsuario(USUARIO _usuario, int idperfil)
        {
            ClsUsuario usuario = new ClsUsuario();
            usuario.usuario = _usuario;
            return usuario.Insertar(idperfil);
        }
        [HttpGet]
        [Route("ListarUsuarios")]
        public IQueryable ListarUsuarios()
        {
            ClsUsuario usuario = new ClsUsuario();
            return usuario.ListarUsuariosEmpleados();
        }
    }
}