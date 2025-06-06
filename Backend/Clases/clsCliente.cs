using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class clsCliente
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public CLIENTE cliente { get; set; }
    
        public string AgregarCliente()
        {
            dbLavadero.CLIENTEs.Add(cliente);
            dbLavadero.SaveChanges();
            return "Se ha guardado con exito el cliente: " + cliente.NOMBRE + " " + cliente.APELLIDO;

        }
        public CLIENTE ConsultarCliente(string documento)
        {
            return dbLavadero.CLIENTEs.FirstOrDefault(c => c.DOCUMENTO == documento);

        }
        public List<CLIENTE> ListaClientes()
        {
            return dbLavadero.CLIENTEs
                .OrderBy(c => c.NOMBRE)
                .ToList();
        }

        public IQueryable ListarClientes()
        {
            return from C in dbLavadero.Set<CLIENTE>()
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEdit\" class=\"btn-block btn-sm btn-danger\" " +
                                "onClick=\"Editar('" + C.DOCUMENTO + "','" + C.NOMBRE + "','" + C.APELLIDO + "','" + C.TELEFONO +
                                "','" + C.EMAIL + "','" + C.DIRECCION + "')\">EDITAR</button>",

                       DOCUMENTO = C.DOCUMENTO,
                       NOMBRE = C.NOMBRE,
                       APELLIDO = C.APELLIDO,
                       TELEFONO = C.TELEFONO,
                       EMAIL = C.EMAIL,
                       DIRECCION = C.DIRECCION,
                   };
        }
        public string ActualizarCliente()
        {
            dbLavadero.CLIENTEs.AddOrUpdate(cliente);
            dbLavadero.SaveChanges();
            return "Se ha actualizado con exito la información de: " + cliente.NOMBRE + " " + cliente.APELLIDO;

        }
        public string EliminarCliente()
        {
            CLIENTE _cliente = ConsultarCliente(cliente.DOCUMENTO);
            dbLavadero.CLIENTEs.Remove(_cliente);
            dbLavadero.SaveChanges();
            return "Se ha eliminado con exito el cliente: " + cliente.NOMBRE + " " + cliente.APELLIDO;
        }
    }
}
