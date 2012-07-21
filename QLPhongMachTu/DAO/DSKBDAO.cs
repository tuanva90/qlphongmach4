using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
   public class DSKBDAO
    {
        private ConectData conectData = new ConectData();
        public int insert(DSKBDTO cd )
        {
            string sql = "insert into DANHSACHKHAMBENH values (@MaBenhNhan,@NgayKham)";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0]= new SqlParameter("@MaBenhNhan", cd.MaBenhNhan);
            sp[1] = new SqlParameter("@NgayKham", cd.NgayKham);
            try
            {
                return conectData.Insert_Update_Delete(sql, sp);
            }
            catch (Exception ex)
            {
                return -2; //can't insert because exist primarykey
            }
        }
        public int delete(DSKBDTO dto)
        {
            int result;
            string sql = "delete from DANHSACHKHAMBENH WHERE MaBenhNhan=@MaBenhNhan and NgayKham=@NgayKham";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@MaBenhNhan", dto.MaBenhNhan);
            sp[1] = new SqlParameter("@NgayKham", dto.NgayKham);
            try
            {
                result=conectData.Insert_Update_Delete(sql, sp);
            }
            catch (Exception ex)
            {
                return -2;// can't delete
            }
            return result;
        }
        public DSKBDTO[] getList()// list of all DSKB
        {
            DSKBDTO[] list;
            string sql = " select * from DANHSACHKHAMBENH ";
          
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new DSKBDTO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list[i] = new DSKBDTO();
                    list[i].MaBenhNhan = dt.Rows[i]["MaBenhNhan"].ToString();
                    list[i].NgayKham = dt.Rows[i]["NgayKham"].ToString();
                }
            }
            return list;
        }
           }
}
