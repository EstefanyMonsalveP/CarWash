using Servicios_lavadero.Clases;
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
    [RoutePrefix("api/Perfiles")]
    public class PerfilesController : ApiController
    {
        [HttpGet]
        [Route("ListarPerfiles")]
        public IQueryable ListarPerfiles()
        {
            ClsPerfil perfil = new ClsPerfil();
            return perfil.ListarPerfiles();
        }
    }
}