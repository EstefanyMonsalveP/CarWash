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
    public class FacturasController: ApiController
    {
        // GET api/<controller>/
        public FACTURA Get(int idFactura)
        {
            clsFactura _clsFactura = new clsFactura();
            return _clsFactura.ConsultarFactura(idFactura);
        }

        //GET api/<controller>/
        public List<FACTURA> Get()
        {
            clsFactura _clsFactura = new clsFactura();
            return _clsFactura.Facturas();
        }

        public string Post([FromBody]FacturaConServiciosDTO)
        {
            clsFactura _clsFactura = new clsFactura();
            
        }
    }
}