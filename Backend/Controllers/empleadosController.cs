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
    public class empleadosController : ApiController
    {
        public IQueryable Get()
        {
            clsEmpleado empleado = new clsEmpleado();
            return empleado.ListaEmpleados();
        }

        // GET api/<controller>/5
        public EMPLEADO Get(string cedula)
        {
            clsEmpleado empleado = new clsEmpleado();
            return empleado.ConsultarEmpleado(cedula);
        }

        /*[HttpGet]
        [Route("ConsultarConCargo")]
        public IQueryable ConsultarConCargo(string Documento)
        {
            clsEmpleado _empleado = new clsEmpleado();
            return _empleado.ConsultarConCargo(Documento);
        }*/

        // POST api/<controller>
        public string Post([FromBody] EMPLEADO empleado_nuevo)
        {
            clsEmpleado _empleado = new clsEmpleado();
            _empleado.empleado = empleado_nuevo;
            return _empleado.AgregarEmpleado();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] EMPLEADO empleado_actualizar)
        {
            clsEmpleado _empleado = new clsEmpleado();
            _empleado.empleado = empleado_actualizar;
            return _empleado.ActualizarEmpleado();
        }

        // DELETE api/<controller>/5
        public string Delete([FromBody] EMPLEADO empleado_eliminiar)
        {
            clsEmpleado _empleado = new clsEmpleado();
            _empleado.empleado = empleado_eliminiar;
            return _empleado.EliminarEmpleado();
        }
    }
}