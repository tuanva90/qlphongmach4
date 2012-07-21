using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;
using System.Data;
namespace DAO
{
  public class PhieuKhamBenhDAO
    {
        private ConectData conectData = new ConectData();
        public int insert(PhieuKhamBenhDTO cd)
        {
            string sql = "insert into PHIEUKHAMBENH values (@MaPhieuKhamBenh,@MaBenhNhan,@NgayKham,@TrieuChung,@MaLoaiBenh,@MaLoaiBenhPhu)";
            SqlParameter[] sp = new SqlParameter[6];
            sp[0] = new SqlParameter("@MaPhieuKhamBenh", cd.MaPhieuKhamBenh);
            sp[1] = new SqlParameter("@MaBenhNhan", cd.MaBenhNhan);
            sp[2] = new SqlParameter("@NgayKham", cd.NgayKham);
            sp[3] = new SqlParameter("@TrieuChung", cd.TrieuChung);
            sp[4] = new SqlParameter("@MaLoaiBenh", cd.MaLoaiBenh);
            sp[5] = new SqlParameter("@MaLoaiBenhPhu", cd.MaLoaiBenhPhu);
            try
            {
                return conectData.Insert_Update_Delete(sql, sp);
            }
            catch
            {
                return -2;
            }
        }
        public int update(PhieuKhamBenhDTO cd)
        {
            string sql = "update PHIEUKHAMBENH set TrieuChung=@TrieuChung, MaLoaiBenh=@MaLoaiBenh,MaLoaiBenhPhu=@MaLoaiBenhPhu where MaPhieuKhamBenh=@MaPhieuKham";
            SqlParameter[] sp = new SqlParameter[4];           
            sp[0] = new SqlParameter("@TrieuChung", cd.TrieuChung);
            sp[1] = new SqlParameter("@MaLoaiBenh", cd.MaLoaiBenh);
            sp[2] = new SqlParameter("@MaLoaiBenhPhu", cd.MaLoaiBenhPhu);
            sp[3] = new SqlParameter("@MaPhieuKham", cd.MaPhieuKhamBenh);
            return conectData.Insert_Update_Delete(sql, sp);
        }
     
        public PhieuKhamBenhDTO getByPrimaryKey(string maphieukham)//
        {
            PhieuKhamBenhDTO pkb = new PhieuKhamBenhDTO();
            string sql = " select * from PHIEUKHAMBENH Where MaPhieuKhamBenh=@MaPhieuKhamBenh ";
            SqlParameter sp = new SqlParameter("@MaPhieuKhamBenh", maphieukham);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql,sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                pkb.MaPhieuKhamBenh= dt.Rows[0]["MaPhieuKhamBenh"].ToString();
                pkb.MaBenhNhan = dt.Rows[0]["MaBenhNhan"].ToString();
                pkb.NgayKham= dt.Rows[0]["NgayKham"].ToString();
                pkb.TrieuChung =dt.Rows[0]["TrieuChung"].ToString();
                pkb.MaLoaiBenh = int.Parse(dt.Rows[0]["MaLoaiBenh"].ToString());
                pkb.MaLoaiBenhPhu = int.Parse(dt.Rows[0]["MaLoaiBenhPhu"].ToString());              

            }
            return pkb;
        }
        public int delete(int magv)
        {
            string sql;
            int result;
            SqlParameter sp;
            try
            {
                sql = "delete from PHIEUKHAMBENH where MaPhieuKhamBenh=@MaPK";
                sp = new SqlParameter("@MaPK", magv);
                result = conectData.Insert_Update_Delete(sql, sp);
            }
            catch (Exception ex)
            {
                return -2; // can't delte this CachDung, if this CachDung is not a primary key of any table =>> return -1;
            }
            return result;

        }
        public PhieuKhamBenhDTO[] getListByNgayKham(string ngaykham)// list of phieu kham by NgayKham và chua co trong hoa don.
        {
            PhieuKhamBenhDTO[] list;
            string sql = " select MaBenhNhan from PHIEUKHAMBENH where NgayKham=@NgayKham and MaBenhNhan in  (select substring(MaPhieuKhamBenh,1,5) from HOADON where substring(MaPhieuKhamBenh,6,10)=@NgayKham)";
            DataTable dt = new DataTable();
            SqlParameter sp = new SqlParameter("@NgayKham", ngaykham);
            dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new PhieuKhamBenhDTO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list[i] = new PhieuKhamBenhDTO();
                    list[i].MaBenhNhan = dt.Rows[i]["MaBenhNhan"].ToString();                   
                }
            }
            return list;
        }
        public PhieuKhamBenhDTO[] getListByBenhNhan(string mabn)// list of phieu kham by NgayKham và chua co trong hoa don.
        {
            PhieuKhamBenhDTO[] list;
            string sql = "select * from PHIEUKHAMBENH where MaBenhNhan=@mabenhnhan";
            DataTable dt = new DataTable();
            SqlParameter sp = new SqlParameter("@mabenhnhan", mabn);
            dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new PhieuKhamBenhDTO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list[i] = new PhieuKhamBenhDTO();
                    list[i].MaBenhNhan = dt.Rows[i]["MaBenhNhan"].ToString();
                    list[i].NgayKham = dt.Rows[i]["NgayKham"].ToString();
                    list[i].TrieuChung = dt.Rows[i]["TrieuChung"].ToString();
                    list[i].MaLoaiBenh = int.Parse(dt.Rows[i]["MaLoaiBenh"].ToString());
                    list[i].MaLoaiBenhPhu = int.Parse(dt.Rows[i]["MaLoaiBenhPhu"].ToString());
                }
            }
            return list;
        }
    }
}
