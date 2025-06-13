using Servicios_lavadero.Clases;
using Servicios_lavadero.Models;
using Servicios_lavadero.Models.DTOs;
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

        //GET api/<controller>/
        public List<VistaFacturaServicio> Get()
        {
            clsFactura _clsFactura = new clsFactura();
            return _clsFactura.Facturas();
        }

        //POST api/<controller>
        public string Post([FromBody]  FacturasConServiciosDTO dto)
        {
            clsFactura _clsFactura = new clsFactura();
            _clsFactura._factura = dto.Factura;// Se pasa la factura a la clase
            return _clsFactura.AgregarFactura(dto.Servicios); //Se pasan los servicios al metodo
        }
    }
}