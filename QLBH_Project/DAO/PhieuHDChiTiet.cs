//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuHDChiTiet
    {
        public int MaPhieuHD { get; set; }
        public int MaSP { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> ThanhTien { get; set; }
    
        public virtual PhieuHD PhieuHD { get; set; }
        public virtual SP SP { get; set; }
    }
}
