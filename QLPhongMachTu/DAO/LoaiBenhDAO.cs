using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class LoaiBenhDAO
    {
        private ConectData conectData = new ConectData();
        public int insert(LoaiBenhDTO cd)
        {
            string sql = "insert into LOAIBENH values (@TenLoaiBenh)";
            SqlParameter sp = new SqlParameter("@TenLoaiBenh", cd.TenLoaiBenh);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int update(LoaiBenhDTO cd)
        {
            string sql = "update LOAIBENH set TenLoaiBenh=@TenLoaiBenh where MaLoaiBenh=@MaLoaiBenh";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@TenLoaiBenh", cd.TenLoaiBenh);
            sp[1] = new SqlParameter("@MaLoaiBenh", cd.MaLoaiBenh);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int delete(int ma)
        {
            string sql;
            int result;
            SqlParameter sp;
            try
            {
                sql = "delete from LOAIBENH where MaLoaiBenh=@MaLoaiBenh";
                sp = new SqlParameter("@MaLoaiBenh", ma);
                result = conectData.Insert_Update_Delete(sql, sp);
            }
            catch (Exception ex)
            {
                return -2; // can't delte this CachDung, if this CachDung is not a primary key of any table =>> return -1;
            }
            return result;
        }
        public LoaiBenhDTO getByPrimaryKey(int maloaibenh)
        {
            LoaiBenhDTO dv = new LoaiBenhDTO();
            string sql = " select * from LOAIBENH  where MaLoaiBenh=@MaLoaiBenh";
            SqlParameter sp = new SqlParameter("@MaLoaiBenh", maloaibenh);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
        
                dv.MaLoaiBenh = int.Parse(dt.Rows[0]["MaLoaiBenh"].ToString());
                dv.TenLoaiBenh = dt.Rows[0]["TenLoaiBenh"].ToString();

            }
            return dv;
        }
        public LoaiBenhDTO[] getList()// list of all LoaiBenh
        {
            LoaiBenhDTO[] list;
            string sql = " select * from LOAIBENH";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new LoaiBenhDTO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list[i] = new LoaiBenhDTO();
                    list[i].MaLoaiBenh = int.Parse(dt.Rows[i]["MaLoaiBenh"].ToString());
                    list[i].TenLoaiBenh = dt.Rows[i]["TenLoaiBenh"].ToString();
                }
            }
            return list;
        }
        public bool CheckExist(string tenLoaiBenh)
        {
            LoaiBenhDTO[] list = getList();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].TenLoaiBenh.ToUpper().Equals(tenLoaiBenh.ToUpper()))
                    return true;
            }
            return false;
        }
    }
}
