using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class clsQueja_Reclamo
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public QUEJA_RECLAMO _quejaReclamo {  get; set; }

        public string AgregarQueja()
        {
            dbLavadero.QUEJA_RECLAMO.Add(_quejaReclamo);
            dbLavadero.SaveChanges();
            return "Se ha agregado la queja de : " + _quejaReclamo.CEDULA_CLIENTE + "con exito";
        }

        public QUEJA_RECLAMO ConsultarQueja(int idQueja)
        {
           return dbLavadero.QUEJA_RECLAMO.FirstOrDefault(qr=>qr.ID_QUEJA == idQueja);
            
        }
        public IQueryable ListarQuejas()
        {
            return from QR in dbLavadero.Set<QUEJA_RECLAMO>()
                   join C in dbLavadero.Set<CLIENTE>()
                   on QR.CEDULA_CLIENTE equals C.DOCUMENTO
                   orderby C.NOMBRE
                   select new
                   {
                       ID_QUEJA = QR.ID_QUEJA,
                       DESCRIPCIÓN_QUEJA = QR.DESCRIPCIÓN_QUEJA,
                       CEDULA_CLIENTE = C.DOCUMENTO + " " + C.NOMBRE + " " + C.APELLIDO
                   };
        }
        public string ActualizarQueja()
        {
            dbLavadero.QUEJA_RECLAMO.AddOrUpdate(_quejaReclamo);
            dbLavadero.SaveChanges();
            return "Se ha actualizado con exito la Queja/Reclamo de: " + _quejaReclamo.CEDULA_CLIENTE ;
        }
        public string EliminarQueja()
        {
            QUEJA_RECLAMO quejaReclamo = ConsultarQueja(_quejaReclamo.ID_QUEJA);
            dbLavadero.QUEJA_RECLAMO.Remove(quejaReclamo);
            dbLavadero.SaveChanges();
            return "Se ha eliminado la queja con id " + " " +_quejaReclamo.ID_QUEJA + "del usuario:" + _quejaReclamo.CEDULA_CLIENTE;
        }


    }
}