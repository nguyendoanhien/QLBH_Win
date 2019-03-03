#region
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using DTO;
#endregion

namespace DAO
{
    public class NhanVien_DAO 
    {
        public static bool KiemTraNhanVien(Nv obj)
        {
            QLBH_WinEntities a = new QLBH_WinEntities();
            return a.NVs.Any(nv => nv.MaNV == obj.MaNv && nv.MK == obj.Mk);
        }
    }
}