using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class ClsPerfil
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public IQueryable ListarPerfiles()
        {
            return from P in dbLavadero.Set<PERFIL>()
                   select new
                   {
                       id = P.id,
                       nombre = P.nombre
                   };
        }
    }
}