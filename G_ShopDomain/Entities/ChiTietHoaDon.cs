//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace G_ShopDomain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietHoaDon
    {
        public int MaChiTietHoaDon { get; set; }
        public int MaHoaDon { get; set; }
        public int MaCaThe { get; set; }
    
        public virtual CaThe CaThe { get; set; }
        public virtual HoaDon HoaDon { get; set; }
    }
}
