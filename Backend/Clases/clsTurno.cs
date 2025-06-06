using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class clsTurno
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public TURNO _turno {  get; set; }

        public List<TURNO> ConsultaTurno()
        {
            return dbLavadero.TURNOS
                .OrderBy(t => t.DESCRIPCION_TURNO)
                .ToList();
        }
    }
}