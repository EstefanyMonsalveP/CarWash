using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class clsVehiculo
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public VEHICULO vehiculo { get; set; }

        public string AgregarVehiculo()
        {
            dbLavadero.VEHICULOes.Add(vehiculo);
            dbLavadero.SaveChanges();
            return "Se ha guardado con exito el vehiculo de placa: " + vehiculo.PLACA;

        }
        public VEHICULO ConsultarVehiculo(string placa)
        {
            return dbLavadero.VEHICULOes.FirstOrDefault(v => v.PLACA == placa);

        }
        public IQueryable ListaVehiculo()
        {
            return from V in dbLavadero.Set<VEHICULO>()
                   join TV in dbLavadero.Set<TIPOVEHICULO>()
                   on V.TIPO equals TV.ID
                   join C in dbLavadero.Set<CLIENTE>()
                   on V.PROPIETARIO  equals C.DOCUMENTO
                   orderby C.NOMBRE
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEdit\" class=\"btn-block btn-sm btn-danger\" " +
                                "onClick=\"Editar('" + V.PLACA + "','" + V.MODELO + "','" + C.DOCUMENTO + "','" + TV.ID + "')\">EDITAR</button>",

                       PLACA = V.PLACA,
                       MODELO = V.MODELO,
                       PROPIETARIO = C.NOMBRE + " " + C.APELLIDO,
                       TIPOVEHICULO = TV.DESCRIPCION,
                   };
        }
        public string ActualizarVehiculo()
        {
            dbLavadero.VEHICULOes.AddOrUpdate(vehiculo);
            dbLavadero.SaveChanges();
            return "Se ha actualizado con exito la información del vehiculo placa: " + vehiculo.PLACA;

        }
        public string EliminarVehiculo()
        {
            VEHICULO _vehiculo = ConsultarVehiculo(vehiculo.PLACA);
            dbLavadero.VEHICULOes.Remove(_vehiculo);
            dbLavadero.SaveChanges();
            return "Se ha eliminado el vehiculo placa: " + vehiculo.PLACA;
        }
    }
}