using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class ClsProducto
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public PRODUCTO producto { get; set; }
        public string agregarProducto()
        {
            dbLavadero.PRODUCTOes.Add(producto);
            dbLavadero.SaveChanges();
            return "Se ha guardado con exito el producto: " + producto.DESCRIPCION_PRO;
        }
        public PRODUCTO ConsultarProducto(int id_producto)
        {
            return dbLavadero.PRODUCTOes.FirstOrDefault(p => p.ID_PRODUCTO == id_producto);
        }
        public List<PRODUCTO> ListaProductos()
        {
            return dbLavadero.PRODUCTOes
                .OrderBy(p => p.DESCRIPCION_PRO)
                .ToList();
        }
        public IQueryable ListarProductos()
        {
            return from P in dbLavadero.Set<PRODUCTO>()
                   join TP in dbLavadero.Set<TIPO_PRODUCTO>()
                   on P.TIPO_PRO equals TP.ID 
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEdit\" class=\"btn-block btn-sm btn-danger\" " +
                                "onClick=\"Editar('" + P.ID_PRODUCTO + "','" + P.DESCRIPCION_PRO + "','" + TP.ID + "','" + P.VALOR_PRODUCTO + "')\">EDITAR</button>",

                       ID_PRODUCTO = P.ID_PRODUCTO,
                       DESCRIPCION_PRO = P.DESCRIPCION_PRO,
                       TIPO_PRO = TP.DESCRIPCION,
                       VALOR_PRODUCTO = P.VALOR_PRODUCTO,
                   };
        }
        public string ActualizarProducto()
        {
            dbLavadero.PRODUCTOes.AddOrUpdate(producto);
            dbLavadero.SaveChanges();
            return "Se ha actualizado con exito la información del producto: " + producto.DESCRIPCION_PRO;

        }
        public string EliminarProducto()
        {
            PRODUCTO _producto = ConsultarProducto(producto.ID_PRODUCTO);
            dbLavadero.PRODUCTOes.Remove(producto);
            dbLavadero.SaveChanges();
            return "Se ha eliminado con exito el producto: " + _producto.DESCRIPCION_PRO;
        }
    }
}