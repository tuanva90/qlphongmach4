using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class CT_KhamDAO
    {
        private ConectData conectData = new ConectData();
        public int insert(CT_KhamDTO cd)
        {
            string sql = "insert into CT_KHAM values (@MaPhieuKhamBenh,@MaLoaiThuoc,@SoLuong,@MaCachDung,@DonGia)";
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@MaPhieuKham", cd.MaPhieuKhamBenh);
            sp[1] = new SqlParameter("@MaLoaiThuoc", cd.MaLoaiThuoc);
            sp[2] = new SqlParameter("@SoLuong", cd.SoLuong);
            sp[3] = new SqlParameter("@MaCachDung", cd.MaCachDung);
            sp[4] = new SqlParameter("@DonGia", cd.DonGia);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int update(CT_KhamDTO cd)
        {
            string sql = "update CT_KHAM set Soluong=@SoLuong, MaCachDung=@MaCachDung, DonGia=@DonGia, WHERE MaPhieuKham=@MaPhieuKham and MaLoaiThuoc=@MaLoaiThuoc";
            SqlParameter[] sp = new SqlParameter[5];            
            sp[0] = new SqlParameter("@SoLuong", cd.SoLuong);
            sp[1] = new SqlParameter("@MaCachDung", cd.MaCachDung);
            sp[2] = new SqlParameter("@DonGia", cd.DonGia);
            sp[3] = new SqlParameter("@MaPhieuKham", cd.MaPhieuKhamBenh);
            sp[4] = new SqlParameter("@MaLoaiThuoc", cd.MaLoaiThuoc);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public CT_KhamDTO getByPrimaryKey(string maphieukham, string maloaithuoc)// list of all benhnhan
        {          
            string sql = " select * from CT_KHAM Where WHERE MaPhieuKham=@MaPhieuKham and MaLoaiThuoc=@MaLoaiThuoc ";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaPhieuKham", maphieukham);
            sp[1] = new SqlParameter("@MaLoaiThuoc", maloaithuoc);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql,sp);
            CT_KhamDTO ctk;
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                 ctk = new CT_KhamDTO();
                ctk.MaPhieuKhamBenh = int.Parse(dt.Rows[0]["MaPhieuKham"].ToString());
                ctk.MaLoaiThuoc = int.Parse(dt.Rows[0]["MaLoaiThuoc"].ToString());
                ctk.SoLuong = int.Parse(dt.Rows[0]["SoLuong"].ToString());
                ctk.MaCachDung = int.Parse(dt.Rows[0]["MaCachDung"].ToString());
                ctk.DonGia = float.Parse(dt.Rows[0]["DonGia"].ToString()); 
            }
            return ctk;
        }
        public int delete(string maphieukham, string maloaithuoc)// list of all benhnhan
        {
            int result;
            string sql = " delete from CT_KHAM Where WHERE MaPhieuKham=@MaPhieuKham and MaLoaiThuoc=@MaLoaiThuoc ";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaPhieuKham", maphieukham);
            sp[1] = new SqlParameter("@MaLoaiThuoc", maloaithuoc);
            try
            {
                result= conectData.Insert_Update_Delete(sql, sp);
            }
            catch (Exception ex)
            {
                return -2; // can't delete
            }
            return result;
        }
    }
}
