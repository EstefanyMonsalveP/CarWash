using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Models.DTOs
{
    public class FacturaDTO
    {
        public DateTime? FECHA { get; set; }
        public string DOCUMENTO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string CEDULA { get; set; } // del empleado
        public string ID_PAGO { get; set; }
        public string DESCRIPCION_PAGO { get; set; }
        public string SERVICIOS { get; set; }
    }
}