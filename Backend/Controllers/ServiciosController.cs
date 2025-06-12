using Servicios_lavadero.Clases;
using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicios_lavadero.Controllers
{
    [EnableCors(origins: "https://localhost:44315", headers: "*", methods: "*")]
    public class ServiciosController: ApiController
    {
        //GET
        public List<SERVICIO> get()
        {
            clsServicio _clsServicio = new clsServicio();
            return _clsServicio.ConsultaServicios();
        }
    }
}