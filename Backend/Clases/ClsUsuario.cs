using Servicios_lavadero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_lavadero.Clases
{
    public class ClsUsuario
    {
        private LAVADEROEntities dbLavadero = new LAVADEROEntities();
        public USUARIO usuario {  get; set; }
        public string Insertar(int idperfil)
        {
            ClsCypher Cifrado = new ClsCypher();
            Cifrado.Password = usuario.clave;
            if (Cifrado.CifrarClave())
            {
                usuario.clave = Cifrado.PasswordCifrado;
                usuario.salt = Cifrado.Salt;
                dbLavadero.USUARIOs.Add(usuario);
                dbLavadero.SaveChanges();

                USUARIO_PERFIL usuario_perfil = new USUARIO_PERFIL();
                usuario_perfil.id_perfil = idperfil;
                usuario_perfil.activo = true;
                usuario_perfil.id_usuario = usuario.id;
                dbLavadero.USUARIO_PERFIL.Add(usuario_perfil);
                dbLavadero.SaveChanges();
                return "Se ingreso el usuario: " + usuario.userName;
            }
            else
            {
                return "No se pudo generar la clave del usuario";
            }
        }

        public IQueryable ListarUsuariosEmpleados()
        {
            return from E in dbLavadero.Set<EMPLEADO>()
                   join EC in dbLavadero.Set<CARGO>()
                   on E.CARGO equals EC.ID
                   join U in dbLavadero.Set<USUARIO>()
                   on E.CEDULA equals U.documento_empleado
                   join UP in dbLavadero.Set<USUARIO_PERFIL>()
                   on U.id equals UP.id_usuario
                   join P in dbLavadero.Set<PERFIL>()
                   on UP.id_perfil equals P.id
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEdit\" class=\"btn-block btn-sm btn-danger\" " +
                                "onClick=\"Editar('" + E.CEDULA + "','" + E.NOMBRE + " " + E.APELLIDO + "','" + EC.ID +
                                "','" + U.userName + "','" + UP.id_perfil + "')\">EDITAR</button>",
                       Documento = E.CEDULA,
                       Empleado = E.NOMBRE + " " + E.APELLIDO,
                       Cargo = EC.DESCRIPCION,
                       Usuario = U.userName,
                       Perfil = P.nombre
                   };
        }
    }
}