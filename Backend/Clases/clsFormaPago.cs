using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class clsFormaPago
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();

        public FORMA_PAGO formaPago { get; set; }

        public List<FORMA_PAGO> ConsultarMetodosPago()
        {
            return dbLavadero.FORMA_PAGO
                .OrderBy(fp => fp.DESCRIPCION_PAGO)
                .ToList();
        }
    }
}