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
    public class Queja_ReclamosController : ApiController
    {
        public IQueryable Get()
        {
            clsQueja_Reclamo _clsQuejaReclamo = new clsQueja_Reclamo();
            return _clsQuejaReclamo.ListarQuejas();
        }

        // GET api/<controller>/5
        public QUEJA_RECLAMO Get(int idQueja)
        {
            clsQueja_Reclamo _clsQuejaReclamo = new clsQueja_Reclamo();
            return _clsQuejaReclamo.ConsultarQueja(idQueja);
        }

        // POST api/<controller>
        public string Post([FromBody] QUEJA_RECLAMO _quejaReclamo)
        {
            clsQueja_Reclamo _clsQuejaReclamo = new clsQueja_Reclamo();
            _clsQuejaReclamo._quejaReclamo = _quejaReclamo;
            return _clsQuejaReclamo.AgregarQueja();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] QUEJA_RECLAMO quejaReclamo_actualizar)
        {
            clsQueja_Reclamo _clsQuejaReclamo = new clsQueja_Reclamo();
            _clsQuejaReclamo._quejaReclamo = quejaReclamo_actualizar;
            return _clsQuejaReclamo.ActualizarQueja();
        }

        // DELETE api/<controller>/5
        //public string Delete([FromBody] QUEJA_RECLAMO quejaReclamo_eliminiar)
        //{
        //    clsQueja_Reclamo _clsQuejaReclamo = new clsQueja_Reclamo();
        //    _clsQuejaReclamo._quejaReclamo = quejaReclamo_eliminiar;
        //    return _clsQuejaReclamo.EliminarQueja();
        //}
    }
}