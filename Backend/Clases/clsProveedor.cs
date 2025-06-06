using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class clsProveedor
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public PROVEEDORE proveedores { get; set; }

        public string AgregarProveedor()
        {
            dbLavadero.PROVEEDORES.Add(proveedores);
            dbLavadero.SaveChanges();
            return "Se ha guardado con exito el proveedor: " + proveedores.NOMBRE ;

        }
        public PROVEEDORE ConsultarProveedor(int id)
        {
            return dbLavadero.PROVEEDORES.FirstOrDefault(p => p.ID_PROVEEDOR == id);

        }
        public List<PROVEEDORE> ListaProveedores()
        {
            return dbLavadero.PROVEEDORES
                .OrderBy(p => p.NOMBRE)
                .ToList();
        }

        public IQueryable ListarProveedores()
        {
            return from P in dbLavadero.Set<PROVEEDORE>()
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEdit\" class=\"btn-block btn-sm btn-danger\" " +
                                "onClick=\"Editar('" + P.ID_PROVEEDOR + "','" + P.NOMBRE + "','" + P.EMAIL + "','" + P.DIRECCION + "')\">EDITAR</button>",

                       ID_PROVEEDOR = P.ID_PROVEEDOR,
                       NOMBRE = P.NOMBRE,
                       EMAIL = P.EMAIL,
                       DIRECCION = P.DIRECCION
                   };
        }
        public string ActualizarProveedor()
        {
            dbLavadero.PROVEEDORES.AddOrUpdate(proveedores);
            dbLavadero.SaveChanges();
            return "Se ha actualizado con exito la información de: " + proveedores.NOMBRE;

        }
        public string EliminarProveedor()
        {
            PROVEEDORE _proveedor = ConsultarProveedor(proveedores.ID_PROVEEDOR);
            dbLavadero.PROVEEDORES.Remove(_proveedor);
            dbLavadero.SaveChanges();
            return "Se ha eliminado con exito el Proveedor: " + proveedores.NOMBRE ;
        }
    }
}
