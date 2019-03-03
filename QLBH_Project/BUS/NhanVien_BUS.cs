#region
using DAO;
using DTO;
#endregion

namespace BUS
{
    public class NhanVien_BUS
    {
        public static bool KiemTraNhanVien(Nv obj)
        {
            return NhanVien_DAO.KiemTraNhanVien(obj);
        }
    }
}