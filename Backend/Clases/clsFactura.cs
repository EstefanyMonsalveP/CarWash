using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class clsFactura
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public FACTURA _factura { get; set; }
        public FACTURA_SERVICIO factura_servicio { get; set; }
        public VistaFacturaServicio _vistaFacturaServicio {  get; set; }
       

        public string AgregarFactura(List <FACTURA_SERVICIO> servicios)
        {
            //Insertar los datos en la tabla de FACTURAS
            dbLavadero.FACTURAs.Add(_factura);
            dbLavadero.SaveChanges();
            int id= _factura.ID_FACTURA;//Retornar el ID de la factura

            //Por cada servicio agregado, insertar en la tabla FACTURA_SERVICIO con el id de la factura
            foreach(FACTURA_SERVICIO servicio in servicios)
            {
                FACTURA_SERVICIO datosFacturaServicio = new FACTURA_SERVICIO
                {
                    ID_FACTURA = id,
                    ID_SERVICIO = servicio.ID_SERVICIO,  
                    CANTIDAD = servicio.CANTIDAD
                };

                //Agregar a la tabla factura
                dbLavadero.FACTURA_SERVICIO.Add(datosFacturaServicio);
            }
            dbLavadero.SaveChanges();

            return "Se genero correctamente la factura";
        }

        //Consultar una factura
        public VistaFacturaServicio ConsultarFactura(int idFactura)
        {
            return dbLavadero.VistaFacturaServicios.FirstOrDefault(f=> f.ID_FACTURA == idFactura);
        }

        //Listar las facturas
        public List<VistaFacturaServicio> Facturas()
        {
            return dbLavadero.VistaFacturaServicios.OrderBy(f=> f.ID_FACTURA).ToList();
        }
    }

    
}