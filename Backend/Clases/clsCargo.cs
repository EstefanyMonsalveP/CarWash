using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class clsCargo
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public CARGO cargoEmpleado { get; set; }
        public List<CARGO> ConsultaCargo()
        {
            return dbLavadero.CARGOS
                .OrderBy(c => c.DESCRIPCION)
                .ToList();
        }
    }
}