//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YayineviYonetimSistemi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Yazarlar
    {
        public int yazarID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Nullable<int> kitapID { get; set; }
    
        public virtual Kitaplar Kitaplar { get; set; }
    }
}
