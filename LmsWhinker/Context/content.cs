//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LmsWhinker.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class content
    {
        public int idContent { get; set; }
        public string contentCourse { get; set; }
        public System.DateTime dateCreation { get; set; }
        public string userCreation { get; set; }
        public System.DateTime dateChange { get; set; }
        public string userChange { get; set; }
        public int idCourse { get; set; }
    
        public virtual course course { get; set; }
    }
}
