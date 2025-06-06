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
    public class Tipo_ProductosController : ApiController
    {
        // GET api/<controller>
        public List<TIPO_PRODUCTO> Get()
        {
            clsTipo_Producto _clsTipoProducto = new clsTipo_Producto();
            return _clsTipoProducto.ListarTipoProductos();
        }
       
    }
}