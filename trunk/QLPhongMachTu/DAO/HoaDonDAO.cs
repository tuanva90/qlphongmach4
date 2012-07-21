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
        public HoaDonDTO[] getBaoCaoThang(int thang, int nam)//lâp bao cao thang, lay danh sach tat ca cac benh nhan co kham trong thang, năm...
        {
            HoaDonDTO[] list;
            string sql = " select MaPhieuKhamBenh from HOADON where left(Substring(MaPhieuKhamBenh,6,10),Charindex('/',Substring(MaPhieuKhamBenh,6,10),0)-1)=@thang and right(Substring(MaPhieuKhamBenh,6,10),4)=@nam";
            DataTable dt = new DataTable();
           SqlParameter[] sp = new SqlParameter[2];
             sp[0] = new SqlParameter("@thang", thang);
             sp[1] = new SqlParameter("@nam", nam);
            dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new HoaDonDTO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list[i] = new HoaDonDTO();
                    list[i].MaPhieuKhamBenh = dt.Rows[i]["MaPhieuKhamBenh"].ToString();
                }
            }
            return list;
        }
        public HoaDonDTO[] getLisByBenhNhan(string mabn)//lâp bao cao thang, lay danh sach tat ca cac benh nhan co kham trong thang, năm...
        {
            HoaDonDTO[] list;
            string sql = " select * from HOADON where substring(MaPhieuKhamBenh,1,5)=@MaBenhNhan";
            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@MaBenhNhan",mabn);
            dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new HoaDonDTO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list[i] = new HoaDonDTO();
                    list[i].MaPhieuKhamBenh = dt.Rows[i]["MaPhieuKhamBenh"].ToString();
                    list[i].TienKham = float.Parse(dt.Rows[i]["TienKham"].ToString());
                    list[i].TienThuoc=float.Parse(dt.Rows[i]["TienThuoc"].ToString());
                }
            }
            return list;
        }
    }
}
