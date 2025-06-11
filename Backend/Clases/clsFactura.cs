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
                };

                //Agregar a la tabla factura
                dbLavadero.FACTURA_SERVICIO.Add(datosFacturaServicio);
            }
            dbLavadero.SaveChanges();


            //Llamar el procedimiento almacenado para realizar la sumatoria de los servicios
            dbLavadero.CalcularTotalFactura(id);

            return "Se genero correctamente la factura";
        }

        //Consultar una factura
        public FACTURA ConsultarFactura(int idFactura)
        {
            return dbLavadero.FACTURAs.FirstOrDefault(f=> f.ID_FACTURA == idFactura);
        }

        //Listar las facturas
        public List<FACTURA> Facturas()
        {
            return dbLavadero.FACTURAs.OrderBy(f=> f.ID_FACTURA).ToList();
        }
    }

    
}