//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinca
{
    using System;
    using System.Collections.Generic;
    
    public partial class Familiares
    {
        public decimal id { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> Id_parentesco { get; set; }
        public Nullable<decimal> Id_finca { get; set; }
    
        public virtual Finca Finca { get; set; }
        public virtual Parentesco Parentesco { get; set; }
    }
}
