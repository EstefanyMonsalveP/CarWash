using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Models.DTOs
{
    public class FacturaYServiciosVistaDTO
    {
        public int ID_FACTURA { get; set; }
        public List<VistaFacturaServicio> Servicios { get; set; }
    }
}