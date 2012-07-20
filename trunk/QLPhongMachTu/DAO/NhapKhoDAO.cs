using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;
using System.Data;
namespace DAO
{
   public class NhapKhoDAO
    {
        private ConectData conectData = new ConectData();
        public int insert(NhapKhoDTO nk)
        {
            string sql = "insert into NHAPKHO values (@MaLoaiThuoc,@NgayNhap,@LanNhap,@SoLuong,@DonGiaNhap)";
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@MaLoaiThuoc", nk.MaLoaiThuoc);
            sp[1] = new SqlParameter("@NgayNhap",nk.NgayNhap);
            sp[2] = new SqlParameter("@LanNhap", nk.LanNhap);
            sp[3] = new SqlParameter("@SoLuong",nk.SoLuong);
            sp[4] = new SqlParameter("@DonGiaNhap", nk.DonGiaNhap);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int getMaxLanNhap(int maloaithuoc)// list of all benhnhan
        {
            int ma;
            string sql = " select MAX(LanNhap) from NHAPKHO where MaLoaiThuoc=@ma";
            SqlParameter sp = new SqlParameter("@ma", maloaithuoc);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql,sp);
            if (dt.Rows[0][0].ToString().Equals("") || dt.Rows[0][0].ToString().Equals(null))
                return 1;
            else
            {
                ma = int.Parse(dt.Rows[0][0].ToString()) + 1;
            }
            return ma;
        }
       
    }
}
