using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Models.DTOs
{
    public class FacturasConServiciosDTO
    {
        public FACTURA Factura { get; set; }
        public List<FACTURA_SERVICIO> Servicios { get; set;}
    }
}