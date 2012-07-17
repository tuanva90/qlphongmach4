using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class CachDungDAO
    {
        private ConectData conectData = new ConectData();
        public int insert(CachDungDTO cd)
        {
            string sql = "insert into CACHDUNG values (@CachDung,@Sang,@Trua,@Chieu,@Toi,@GhiChu)";
            SqlParameter[] sp = new SqlParameter[6];
            sp[0] = new SqlParameter("@CachDung", cd.CachDung);
            sp[1] = new SqlParameter("@Sang", cd.Sang);
            sp[2] = new SqlParameter("@Trua", cd.Trua);
            sp[3] = new SqlParameter("@Chieu", cd.Chieu);
            sp[4] = new SqlParameter("@Toi", cd.Toi);
            sp[5] = new SqlParameter("@GhiChu", cd.Toi);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int update(CachDungDTO cd)
        {
            string sql = "update CACHDUNG set CachDung=@CachDung, Sang=@Sang, Trua=@Trua, Chieu=@Chieu, Toi=@Toi, Ghichu=@GhiChu where MaCachDung=@MaCachDung";
            SqlParameter[] sp = new SqlParameter[7];
            sp[0] = new SqlParameter("@CachDung", cd.CachDung);
            sp[1] = new SqlParameter("@Sang", cd.Sang);
            sp[2] = new SqlParameter("@Trua", cd.Trua);
            sp[3] = new SqlParameter("@Chieu", cd.Chieu);
            sp[4] = new SqlParameter("@Toi", cd.Toi);
            sp[5] = new SqlParameter("@GhiChu", cd.Toi);
            sp[6] = new SqlParameter("@MaCachDung", cd.MaCachDung);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public CachDungDTO[] getList()// list of all benhnhan
        {
           CachDungDTO[] list;
            string sql = " select * from CACHDUNG ";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new CachDungDTO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list[i] = new CachDungDTO();
                    list[i].MaCachDung = int.Parse(dt.Rows[i]["MaCachDung"].ToString());
                    list[i].CachDung = dt.Rows[i]["CachDung"].ToString();
                    list[i].Sang= int.Parse(dt.Rows[i]["Sang"].ToString());
                    list[i].Trua = int.Parse(dt.Rows[i]["Trua"].ToString());
                    list[i].Chieu = int.Parse(dt.Rows[i]["Chieu"].ToString());
                    list[i].Toi = int.Parse(dt.Rows[i]["Toi"].ToString());
                    list[i].GhiChu = dt.Rows[i]["GhiChu"].ToString();
                }
            }
            return list;
        }
        public CachDungDTO getByPrimaryKey(int macachdung)// list of all benhnhan
        {
            CachDungDTO cachdung = new CachDungDTO();
            string sql = " select * from CACHDUNG Where MaCachDung=@MaCachDung ";
            SqlParameter sp = new SqlParameter("@MaCachDung", macachdung);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                 cachdung.MaCachDung = int.Parse(dt.Rows[0]["MaCachDung"].ToString());
                cachdung.CachDung = dt.Rows[0]["CachDung"].ToString();
                cachdung.Sang = int.Parse(dt.Rows[0]["Sang"].ToString());
                cachdung.Trua = int.Parse(dt.Rows[0]["Trua"].ToString());
                cachdung.Chieu = int.Parse(dt.Rows[0]["Chieu"].ToString());
                cachdung.Toi = int.Parse(dt.Rows[0]["Toi"].ToString());
               
            }
            return cachdung;
        }
        public int delete(int magv)
        {
            string sql;
            int result;
            SqlParameter sp;
            try
            {
                 sql = "delete from CACHDUNG where MaCachDung=@MaCachDung";
                 sp = new SqlParameter("@MaCachDung", magv);
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
