using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class PhanQuyenDAO
    {
        private ConectData conectData = new ConectData();
        public int insert(PhanQuyenDTO pq)
        {
            string sql = "insert into PHANQUYEN values (@TenPhanQuyen)";
            SqlParameter sp = new SqlParameter("@TenPhanQuyen", pq.TenPhanQuyen);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int update(PhanQuyenDTO pq)
        {
            string sql = "update PHANQUYEN set TenPhanQuyen=@TenPhanQuyen where MaPhanQuyen=@MaPhanQuyen";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@TenPhanQuyen", pq.TenPhanQuyen);
            sp[1] = new SqlParameter("@MaPhanQuyen", pq.MaPhanQuyen);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int delete(int ma)
        {
            string sql;
            int result;
            SqlParameter sp;
            try
            {
                sql = "delete from PHANQUYEN where MaPhanQuyen=@MaPhanQuyen";
                sp = new SqlParameter("@MaPhanQuyen", ma);
                result = conectData.Insert_Update_Delete(sql, sp);
            }
            catch (Exception ex)
            {
                return -2; // can't delte this CachDung, if this CachDung is not a primary key of any table =>> return -1;
            }
            return result;
        }
        public PhanQuyenDTO getByPrimaryKey(int maPhanQuyen)
        {
            PhanQuyenDTO pq = new PhanQuyenDTO();
            string sql = " select * from PHANQUYEN  where MaPhanQuyen=@MaPhanQuyen";
            SqlParameter sp = new SqlParameter("@MaPhanQuyen", maPhanQuyen);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
        
                pq.MaPhanQuyen = int.Parse(dt.Rows[0]["MaPhanQuyen"].ToString());
                pq.TenPhanQuyen = dt.Rows[0]["TenPhanQuyen"].ToString();

            }
            return pq;
        }
        public PhanQuyenDTO getByTenPhanQuyen(string tenPhanQuyen)
        {
            PhanQuyenDTO pq = new PhanQuyenDTO();
            string sql = " select * from PHANQUYEN  where TenPhanQuyen=@TenPhanQuyen";
            SqlParameter sp = new SqlParameter("@TenPhanQuyen", tenPhanQuyen);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {

                pq.MaPhanQuyen = int.Parse(dt.Rows[0]["MaPhanQuyen"].ToString());
                pq.TenPhanQuyen = dt.Rows[0]["TenPhanQuyen"].ToString();

            }
            return pq;
        }

        public int getMaPhanQuyenFromTenPhanQuyen(string tenPhanQuyen)
        {
            int ikq = -1;
            string sql = " select * from PHANQUYEN  where TenPhanQuyen=@TenPhanQuyen";
            SqlParameter sp = new SqlParameter("@TenPhanQuyen", tenPhanQuyen);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return -1;
            else
            {
                return ikq = int.Parse(dt.Rows[0]["MaPhanQuyen"].ToString());
            }
        }

        public string getTenPhanQuyenFromMaPhanQuyen(int maPhanQuyen)
        {
            string sql = " select * from PHANQUYEN  where MaPhanQuyen=@MaPhanQuyen";
            SqlParameter sp = new SqlParameter("@MaPhanQuyen", maPhanQuyen);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                return dt.Rows[0]["TenPhanQuyen"].ToString();
            }
        }

        public PhanQuyenDTO[] getList()// list of all PhanQuyen
        {
            PhanQuyenDTO[] list;
            string sql = " select * from PHANQUYEN";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new PhanQuyenDTO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list[i] = new PhanQuyenDTO();
                    list[i].MaPhanQuyen = int.Parse(dt.Rows[i]["MaPhanQuyen"].ToString());
                    list[i].TenPhanQuyen = dt.Rows[i]["TenPhanQuyen"].ToString();
                }
            }
            return list;
        }
    }
}
