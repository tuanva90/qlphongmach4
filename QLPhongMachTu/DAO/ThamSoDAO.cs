using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;
using System.Data;
namespace DAO
{
    public class ThamSoDAO
    {
        private ConectData conectData = new ConectData();       
        public int update(float tienkham)
        {
            string sql = "update THAMSO set TienKham=@Tien";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@Tien",sp);          
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int update(int sobntd)
        {
            string sql = "update THAMSO set SoBenhNhanToiDa=@Tien";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@Tien", sobntd);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public ThamSoDTO getThamSo()
        {
            ThamSoDTO ts = new ThamSoDTO();
            string sql = "select * from THAMSO";
            DataTable dt = conectData.LoadData(sql);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                ts.TienKham =float.Parse(dt.Rows[0]["TienKham"].ToString());
                ts.SoBenhNhanToiDa=int.Parse(dt.Rows[0]["SoBenhNhanToiDa"].ToString());              

            }
            return ts;
        }
    }
}
