using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;
namespace DAO
{
   public class HoaDonDAO
    {
        private ConectData conectData = new ConectData();
        public int insert(HoaDonDTO hd)
        {
            string sql = "insert into HOADON values (@MaPhieuKhamBenh,@TienKham,@TienThuoc)";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@MaPhieuKhamBenh", hd.MaPhieuKhamBenh);
            sp[1] = new SqlParameter("@TienKham", hd.TienKham);
            sp[2] = new SqlParameter("@TienTHuoc", hd.TienThuoc);
            try
            {
                return conectData.Insert_Update_Delete(sql, sp);
            }
            catch (Exception ex)
            {
                return -2;
            }
        }
        public HoaDonDTO getByPrimaryKey(string maphieukham)// list of all benhnhan
        {
            string sql = " select * from HOADON Where MaPhieuKhamBenh=@MaPhieuKham";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@MaPhieuKham", maphieukham);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql, sp);
            HoaDonDTO hd;
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                hd = new HoaDonDTO();
                hd.MaPhieuKhamBenh = dt.Rows[0]["MaPhieuKhamBenh"].ToString();
                hd.TienKham = float.Parse(dt.Rows[0]["TienKham"].ToString());
                hd.TienThuoc = float.Parse(dt.Rows[0]["TienThuoc"].ToString());               
            }
            return hd;
        }
    }
}
