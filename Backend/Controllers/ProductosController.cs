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
    public class ProductosController : ApiController
    {
        // GET api/<controller>
        public IQueryable Get()
        {
            ClsProducto producto = new ClsProducto();
            return producto.ListarProductos();
        }

        // GET api/<controller>/5
        public PRODUCTO Get(int id_producto)
        {
            ClsProducto producto = new ClsProducto();
            return producto.ConsultarProducto(id_producto);
        }

        // POST api/<controller>
        public string Post([FromBody] PRODUCTO producto_nuevo)
        {
            ClsProducto _producto = new ClsProducto();
            _producto.producto = producto_nuevo;
            return _producto.agregarProducto();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] PRODUCTO producto_actualizar)
        {
            ClsProducto _producto = new ClsProducto();
            _producto.producto = producto_actualizar;
            return _producto.ActualizarProducto();
        }

        // DELETE api/<controller>/5
        public string Delete([FromBody] PRODUCTO producto_eliminar)
        {
            ClsProducto _producto = new ClsProducto();
            _producto.producto = producto_eliminar;
            return _producto.EliminarProducto();
        }
    }
}