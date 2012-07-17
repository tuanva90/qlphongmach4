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
            string sql = "insert into PHIEUKHAMBENH values (@MaDSKB,@TrieuChung,@MaLoaiBenh,@MaLoaiBenhPhu)";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@MaDSKB", cd.MaDSKB);
            sp[1] = new SqlParameter("@TrieuChung", cd.TrieuChung);
            sp[2] = new SqlParameter("@MaLoaiBenh", cd.MaLoaiBenh);
            sp[3] = new SqlParameter("@MaLoaiBenhPhu", cd.MaLoaiBenhPhu);           
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int update(PhieuKhamBenhDTO cd)
        {
            string sql = "update PHIEUKHAMBENH set MaDSKB=@MaDSKB, TrieuChung=@TrieuChung, MaLoaiBenh=@MaLoaiBenh,MaLoaiBenhPhu=@MaLoaiBenhPhu where MaPhieuKhamBenh=@MaPhieuKham";
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@MaDSKB", cd.MaDSKB);
            sp[1] = new SqlParameter("@TrieuChung", cd.TrieuChung);
            sp[2] = new SqlParameter("@MaLoaiBenh", cd.MaLoaiBenh);
            sp[3] = new SqlParameter("@MaLoaiBenhPhu", cd.MaLoaiBenhPhu);
            sp[4] = new SqlParameter("@MaPhieuKhamBenh", cd.MaPhieuKhamBenh);
            return conectData.Insert_Update_Delete(sql, sp);
        }
     
        public PhieuKhamBenhDTO getByPrimaryKey(int maphieukham)// list of all benhnhan
        {
            PhieuKhamBenhDTO pkb = new PhieuKhamBenhDTO();
            string sql = " select * from PHIEUKHAMBENH Where MaPhieuKhamBenh=@MaPhieuKhamBenh ";
            SqlParameter sp = new SqlParameter("@MaPhieuKhamBenh", maphieukham);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                pkb.MaPhieuKhamBenh= int.Parse(dt.Rows[0]["MaPhieuKhamBenh"].ToString());
                pkb.MaDSKB = dt.Rows[0]["MaDSKB"].ToString();
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
    }
}
