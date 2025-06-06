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
    public class clientesController : ApiController
    {
        // GET api/<controller>
        public IQueryable Get()
        {
            clsCliente cliente = new clsCliente();
            return cliente.ListarClientes();
        }

        // GET api/<controller>/5
        public CLIENTE Get(string documento)
        {
            clsCliente cliente = new clsCliente();
            return cliente.ConsultarCliente(documento);
        }

        // POST api/<controller>
        public string Post([FromBody] CLIENTE cliente_nuevo)
        {
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = cliente_nuevo;
            return _cliente.AgregarCliente();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] CLIENTE cliente_actualizar)
        {
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = cliente_actualizar;
            return _cliente.ActualizarCliente();
        }

        // DELETE api/<controller>/5
        public string Delete([FromBody] CLIENTE cliente_eliminar)
        {
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = cliente_eliminar;
            return _cliente.EliminarCliente();
        }
    }
}