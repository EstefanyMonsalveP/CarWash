//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicios_lavadero.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TELEFONO_PROVEEDOR
    {
        public int ID_PROVEEDOR { get; set; }
        public string TELEFONO { get; set; }
    
        public virtual PROVEEDORE PROVEEDORE { get; set; }
    }
}
