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
    public class VehiculosController : ApiController
    {
        // GET api/<controller>
        public IQueryable Get()
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.ListaVehiculo();
        }

        // GET api/<controller>/5
        public VEHICULO Get(string placa)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.ConsultarVehiculo(placa);
        }

        // POST api/<controller>
        public string Post([FromBody] VEHICULO vehiculo_nuevo)
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            _vehiculo.vehiculo = vehiculo_nuevo;
            return _vehiculo.AgregarVehiculo();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] VEHICULO vehiculo_actualizar)
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            _vehiculo.vehiculo = vehiculo_actualizar;
            return _vehiculo.ActualizarVehiculo();
        }

        // DELETE api/<controller>/5
        public string Delete([FromBody] VEHICULO vehiculo_eliminar)
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            _vehiculo.vehiculo = vehiculo_eliminar;
            return _vehiculo.EliminarVehiculo();
        }
    }
}
