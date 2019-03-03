#region
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;
#endregion

namespace DAO
{
    public class Kh_DAO : ConnectDatabase
    {
        public bool themKh(Kh ng)
        {
          

            return false;
        }

        public bool ThemKh(Kh dg)
        {
          

            return false;
        }

        public string TraVeGiaTriMaLoaiDG(string TenLoaiKh)
        {
            try
            {
                var conn = GetConnString();
                var sql = "select MaLoaiKh from KhLoai where TenLoaiKh = @tenloaiDG";
                SqlParameter[] pars =
                {
                    new SqlParameter("@tenloaiDG", SqlDbType.NVarChar)
                    {
                        Value = TenLoaiKh
                    }
                };
                var soLuongOK = SqlHelper.ExecuteScalar(conn, sql, CommandType.Text, pars);

                if (soLuongOK != null) return soLuongOK.ToString();
                else return "lỗi";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
        }

        public int MaMax()
        {
            try
            {
                var conn = GetConnString();
                var sql = "select MAX(MaKh) from Kh";
                SqlParameter[] pars = { };
                var soLuongOK = SqlHelper.ExecuteScalar(conn, sql, CommandType.Text, pars);

                var gt = int.Parse(soLuongOK.ToString());

                if (soLuongOK != null) return gt;
                else return 0;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }

            return 0;
        }

        public SqlDataReader getNCC()
        {
            try
            {
                // Ket noi
                var conn = GetConnString();

                // Query string - vì mình để TV_ID là identity (giá trị tự tăng dần) nên ko cần fải insert ID
                var sql =
                    "select a.MaKh,c.TenLoaiKh,b.HoVaTen,b.GioiTinh,b.Email,b.NgayTao from Kh a, Kh b, KhLoai c where a.MaKh = b.MaKh and a.MaLoaiKh = c.MaLoaiKh";
                SqlParameter[] pars = { };


                var soLuongOK = SqlHelper.ExecuteReader(conn, sql, CommandType.Text, pars);

                if (soLuongOK != null) return soLuongOK;

                return null;

                // Query và kiểm tra
            }
            catch (Exception e)
            {
            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }

            return null;
        }

        public static DataTable LoadBangKh()
        {
        
            var dtNCC = new DataTable();
           
            return dtNCC;
        }

        public static DataSet LoadComBoBoxLoaiKh(string tenbang)
        {
            try
            {
                // Ket noi
                var conn = GetConnString();

                // Query string - vì mình để TV_ID là identity (giá trị tự tăng dần) nên ko cần fải insert ID
                var sql = "SELECT * from KhLoai";
                return getdataset(sql, tenbang, _conn);

                // Query và kiểm tra
            }
            catch (Exception e)
            {
            }

            return null;
        }

        public bool XoaKh(int maKh)
        {
            try
            {
                var conn = GetConnString();
                var sql = "Kh_Xoa";
                SqlParameter[] pars =
                {
                    new SqlParameter("@maCanXoa", SqlDbType.Int)
                    {
                        Value = maKh
                    }
                };

                var soLuongOK = SqlHelper.ExecuteNonQuery(conn, sql, CommandType.StoredProcedure, pars);

                if (soLuongOK > 0) return true;

                return false;
            }
            catch (Exception e)
            {
            }

            return false;
        }

        public static bool KiemTraDuocMuon(int maKh)
        {
            var sql = "dbo.KiemTraDuocMuon";
            var pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@MaKh", maKh));

            var kq = SqlHelper.ExecuteScalar(GetConnString(), sql, CommandType.StoredProcedure, pars.ToArray()) as int?;
            return kq == null ? true : kq > 0 ? true : false;
        }

        public static bool KiemTraKh(int maKh)
        {
            var sql = "dbo.KiemTraKh";
            var pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@MaKh", maKh));

            var kq = SqlHelper.ExecuteScalar(GetConnString(), sql, CommandType.StoredProcedure, pars.ToArray()) as int?;
            return kq != null && kq > 0 ? true : false;
        }

        public static int? LaySachMuonToiDa(int maKh)
        {
            var sql = "dbo.KiemTraDuocMuon";
            var pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@MaKh", maKh));

            var kq = SqlHelper.ExecuteScalar(GetConnString(), sql, CommandType.StoredProcedure, pars.ToArray()) as int?;
            return kq;
        }

        public static bool KT_SachMuon(int maKh, int maDauSach)
        {
            var sql = "KiemTraSachMuon";
            var cmd = new SqlCommand();
            cmd.Connection = _conn;
            _conn.Open();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maKh", maKh).Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@maDauSach", maDauSach).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("@kq", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            var outval = (int) cmd.Parameters["@kq"].Value;
            _conn.Close();
            return outval == 1 ? true : false;
        }
    }
}