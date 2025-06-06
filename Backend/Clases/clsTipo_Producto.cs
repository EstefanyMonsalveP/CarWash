using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class clsTipo_Producto
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public TIPO_PRODUCTO _tipoProducto {  get; set; }

        public List<TIPO_PRODUCTO> ListarTipoProductos()
        {
            return dbLavadero.TIPO_PRODUCTO
                .OrderBy(TP => TP.DESCRIPCION)
                .ToList();
        }
    }
}