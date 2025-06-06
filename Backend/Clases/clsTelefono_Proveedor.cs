using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class clsTelefono_Proveedor
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public TELEFONO_PROVEEDOR _telefonoProveedor {  get; set; }

        public List<TELEFONO_PROVEEDOR> ListarTelefonosProveedor()
        {
            return dbLavadero.TELEFONO_PROVEEDOR
                .OrderBy(tp => tp.TELEFONO)
                .ToList();
        }
    }
}