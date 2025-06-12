using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Models.DTOs
{
    //Factura que agrupa los servicios a partir de la vista  'VistaFacturaServicio'
    public class FacturaYServiciosVistaDTO
    {
        public int ID_FACTURA { get; set; }
        public List<VistaFacturaServicio> Servicios { get; set; }
    }
}