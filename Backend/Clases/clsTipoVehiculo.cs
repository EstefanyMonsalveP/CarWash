using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class clsTipoVehiculo
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public TIPOVEHICULO _tipoVehiculo {  get; set; }

        public List<TIPOVEHICULO> ListTipoVehiculos()
        {
            return dbLavadero.TIPOVEHICULOes
                .OrderBy(t => t.DESCRIPCION)
                .ToList();
        }
    }
}