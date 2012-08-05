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
            sp[0] = new SqlParameter("@MaPhieuKhamBenh", cd.MaPhieuKhamBenh);
            sp[1] = new SqlParameter("@MaLoaiThuoc", cd.MaLoaiThuoc);
            sp[2] = new SqlParameter("@SoLuong", cd.SoLuong);
            sp[3] = new SqlParameter("@MaCachDung", cd.MaCachDung);
            sp[4] = new SqlParameter("@DonGia", cd.DonGia);
            try
            {
                return conectData.Insert_Update_Delete(sql, sp);
            }
            catch (Exception ex)
            {
                return -2;
            }
        }
        public int update(CT_KhamDTO cd)
        {
            string sql = "update CT_KHAM set Soluong=@SoLuong, MaCachDung=@MaCachDung, DonGia=@DonGia, WHERE MaPhieuKhamBenh=@MaPhieuKham and MaLoaiThuoc=@MaLoaiThuoc";
            SqlParameter[] sp = new SqlParameter[5];            
            sp[0] = new SqlParameter("@SoLuong", cd.SoLuong);
            sp[1] = new SqlParameter("@MaCachDung", cd.MaCachDung);
            sp[2] = new SqlParameter("@DonGia", cd.DonGia);
            sp[3] = new SqlParameter("@MaPhieuKham", cd.MaPhieuKhamBenh);
            sp[4] = new SqlParameter("@MaLoaiThuoc", cd.MaLoaiThuoc);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public CT_KhamDTO getByPrimaryKey(string maphieukham, int maloaithuoc)// list of all benhnhan
        {          
            string sql = " select * from CT_KHAM Where MaPhieuKhamBenh=@MaPhieuKham and MaLoaiThuoc=@MaLoaiThuoc ";
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
                ctk.MaPhieuKhamBenh = dt.Rows[0]["MaPhieuKhamBenh"].ToString();
                ctk.MaLoaiThuoc = int.Parse(dt.Rows[0]["MaLoaiThuoc"].ToString());
                ctk.SoLuong = int.Parse(dt.Rows[0]["SoLuong"].ToString());
                ctk.MaCachDung = int.Parse(dt.Rows[0]["MaCachDung"].ToString());
                ctk.DonGia = float.Parse(dt.Rows[0]["DonGia"].ToString()); 
            }
            return ctk;
        }
        public DataTable getDonthuoc(string maphieukham)// getDonthuoc
        {
            string sql = " select substring(ct.MaPhieuKhamBenh,1,5) as MaBenhNhan, substring(ct.MaPhieuKhamBenh,6,10) as NgayKham, ct.MaLoaiThuoc, ct.MaCachDung,ct.SoLuong, ct.DonGia,lt.TenLoaiThuoc  from CT_KHAM ct, LOAITHUOC lt Where lt.MaLoaiThuoc = ct.MaLoaiThuoc and ct.MaPhieuKhamBenh=@MaPhieuKham";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@MaPhieuKham", maphieukham);     
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql, sp);
            return dt;
        }
        public CT_KhamDTO[] getListByMaPhieuKham(string maphieukham)// list of all benhnhan
        {
            CT_KhamDTO[] list;
            string sql = " select * from CT_KHAM Where MaPhieuKhamBenh=@MaPhieuKham";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@MaPhieuKham", maphieukham);           
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql, sp);          
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new CT_KhamDTO[dt.Rows.Count];
                for (int i = 0; i < list.Length; i++)
                {
                    list[i] = new CT_KhamDTO();
                    list[i].MaPhieuKhamBenh = dt.Rows[i]["MaPhieuKhamBenh"].ToString();
                    list[i].MaLoaiThuoc = int.Parse(dt.Rows[i]["MaLoaiThuoc"].ToString());
                    list[i].SoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                    list[i].MaCachDung = int.Parse(dt.Rows[i]["MaCachDung"].ToString());
                    list[i].DonGia = float.Parse(dt.Rows[i]["DonGia"].ToString());
                }
            }
            return list;
        }
        public CT_KhamDTO[] getListMaBenhNhan(string mabn)// list don thuoc by mabenhnhan
        {
            CT_KhamDTO[] list;
            string sql = " select * from CT_KHAM Where substring(MaPhieuKhamBenh,1,5)=@MaPhieuKham";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@MaPhieuKham", mabn);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new CT_KhamDTO[dt.Rows.Count];
                for (int i = 0; i < list.Length; i++)
                {
                    list[i] = new CT_KhamDTO();
                    list[i].MaPhieuKhamBenh = dt.Rows[i]["MaPhieuKhamBenh"].ToString();
                    list[i].MaLoaiThuoc = int.Parse(dt.Rows[i]["MaLoaiThuoc"].ToString());
                    list[i].SoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                    list[i].MaCachDung = int.Parse(dt.Rows[i]["MaCachDung"].ToString());
                    list[i].DonGia = float.Parse(dt.Rows[i]["DonGia"].ToString());
                   // list[i] = float.Parse(dt.Rows[i]["DonGia"].ToString());
                }
            }
            return list;
        }
        public CT_KhamDTO[] getListNgayKham(string ngaykham)// list don thuoc by mabenhnhan
        {
            CT_KhamDTO[] list;
            string sql = " select * from CT_KHAM Where substring(MaPhieuKhamBenh,6,10)=@MaPhieuKham";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@MaPhieuKham", ngaykham);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new CT_KhamDTO[dt.Rows.Count];
                for (int i = 0; i < list.Length; i++)
                {
                    list[i] = new CT_KhamDTO();
                    list[i].MaPhieuKhamBenh = dt.Rows[i]["MaPhieuKhamBenh"].ToString();
                    list[i].MaLoaiThuoc = int.Parse(dt.Rows[i]["MaLoaiThuoc"].ToString());
                    list[i].SoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                    list[i].MaCachDung = int.Parse(dt.Rows[i]["MaCachDung"].ToString());
                    list[i].DonGia = float.Parse(dt.Rows[i]["DonGia"].ToString());
                    // list[i] = float.Parse(dt.Rows[i]["DonGia"].ToString());
                }
            }
            return list;
        }
        public int delete(string maphieukham, int maloaithuoc)// list of all benhnhan
        {
            int result;
            string sql = " delete from CT_KHAM Where MaPhieuKhamBenh=@MaPhieuKham and MaLoaiThuoc=@MaLoaiThuoc ";
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
