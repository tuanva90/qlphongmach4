using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
   public class DonViDAO
    {
        private ConectData conectData = new ConectData();
        public int insert(DonViDTO cd)
        {
            string sql = "insert into DONVI values (@DonViTinh)";
            SqlParameter sp = new SqlParameter("@DonViTinh", cd.DonViTinh);           
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int update(DonViDTO cd)
        {
            string sql = "update DONVI set DonViTinh=@DonViTinh where MaDonViTinh=@MaDonViTinh";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@DonViTinh", cd.DonViTinh);
            sp[1] = new SqlParameter("@MaDonViTinh", cd.MaDonViTinh);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int delete(int madv)
        {
            string sql;
            int result;
            SqlParameter sp;
            try
            {
                sql = "delete from DONVI where MaDonViTinh=@MaDonViTinh";
                sp = new SqlParameter("@MaDonViTinh", madv);
                result = conectData.Insert_Update_Delete(sql, sp);
            }
            catch (Exception ex)
            {
                return -2; // can't delte this CachDung, if this CachDung is not a primary key of any table =>> return -1;
            }
            return result;

        }
        public DonViDTO getByPrimaryKey(int madonvitinh)
        {
           DonViDTO dv= new DonViDTO();
            string sql = " select * from DONVI  where MaDonViTinh=@MaDonViTinh";
            SqlParameter sp = new SqlParameter("@MaDonViTinh",madonvitinh);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
               dv.MaDonViTinh = int.Parse(dt.Rows[0]["MaDonViTinh"].ToString());
               dv.DonViTinh = dt.Rows[0]["DonViTinh"].ToString();
               
            }
            return dv;
        }
        public DonViDTO[] getList()// list of all donvi
        {
            DonViDTO[] list;
            string sql = " select * from DONVI";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new DonViDTO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list[i] = new DonViDTO();
                    list[i].MaDonViTinh= int.Parse(dt.Rows[i]["MaDonViTinh"].ToString());
                    list[i].DonViTinh = dt.Rows[i]["DonViTinh"].ToString();                   
                }
            }
            return list;

        }
    }
}
