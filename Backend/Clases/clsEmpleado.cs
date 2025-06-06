using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class clsEmpleado
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public EMPLEADO empleado { get; set; }
        public string AgregarEmpleado()
        {
            dbLavadero.EMPLEADOes.Add(empleado);
            dbLavadero.SaveChanges();
            return "Se ha guardado con exito el empleado: " + empleado.NOMBRE + " " + empleado.APELLIDO;
        }
        public EMPLEADO ConsultarEmpleado(string cedula)
        {
            return dbLavadero.EMPLEADOes.FirstOrDefault(e => e.CEDULA == cedula);
        }
        public IQueryable ConsultarConCargo(string Documento)
        {
            return from E in dbLavadero.Set<EMPLEADO>()
                   join EC in dbLavadero.Set<CARGO>()
                   on E.CARGO equals EC.ID
                   where E.CEDULA == Documento //&& EC.FechaFin == null
                   select new
                   {
                       NombreEmpleado = E.NOMBRE + " " + E.APELLIDO,
                       Cargo = EC.DESCRIPCION
                   };
        }
        public IQueryable ListaEmpleados()
        {
            return from T in dbLavadero.Set<TURNO>()
                   join E in dbLavadero.Set<EMPLEADO>()
                   on T.ID_TURNO equals E.TURNO
                   join C in dbLavadero.Set<CARGO>()
                   on E.CARGO equals C.ID
                   orderby E.NOMBRE
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEdit\" class=\"btn-block btn-sm btn-danger\" " +
                                "onClick=\"Editar('" + E.CEDULA + "','" + E.NOMBRE + "','" + E.APELLIDO + "','" + E.TELEFONO +
                                "','" + E.DIRECCION + "','" + C.ID + "','" + T.ID_TURNO + "')\">EDITAR</button>",
                       CEDULA = E.CEDULA,
                       NOMBRE = E.NOMBRE,
                       APELLIDO = E.APELLIDO,
                       TELEFONO = E.TELEFONO,
                       DIRECCION = E.DIRECCION,
                       CARGO = C.DESCRIPCION,
                       TURNO = T.DESCRIPCION_TURNO
                   };
        }
        public string ActualizarEmpleado()
        {
            dbLavadero.EMPLEADOes.AddOrUpdate(empleado);
            dbLavadero.SaveChanges();
            return "Se ha actualizado con exito la información de: " + empleado.NOMBRE + " " + empleado.APELLIDO;
        }
        public string EliminarEmpleado()
        {
            EMPLEADO _empleado = ConsultarEmpleado(empleado.CEDULA);
            dbLavadero.EMPLEADOes.Remove(_empleado);
            dbLavadero.SaveChanges();
            return "Se ha eliminado el empleado de nombre: " + empleado.NOMBRE + " " + empleado.APELLIDO;
        }
    }
}