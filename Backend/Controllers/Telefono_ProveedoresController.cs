using Servicios_lavadero.Clases;
using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servicios_lavadero.Controllers
{
    public class Telefono_ProveedoresController : ApiController
    {
        // GET api/<controller>
        public List<TELEFONO_PROVEEDOR> Get()
        {
            clsTelefono_Proveedor _clsTelefonoProveedor = new clsTelefono_Proveedor();
            return _clsTelefonoProveedor.ListarTelefonosProveedor();
        }
       
    }
}