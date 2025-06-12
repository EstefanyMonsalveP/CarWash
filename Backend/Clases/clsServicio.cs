using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases

{
    public class clsServicio
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public SERVICIO _servicio { get; set; }

        public List<SERVICIO> ConsultaServicios()
        {
            return dbLavadero.SERVICIOS
                .OrderBy(s=> s.DESCRIPCION)
                .ToList();
        }
    }
}