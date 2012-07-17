using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class ConectData
    {
        string connection = @"Data Source=ThanhIT-PC\sqlexpress;Initial Catalog=PhongMachTu;Integrated Security=True";
        SqlConnection conn;
        void OpenConnection()
        {
            conn = new SqlConnection(connection);
            conn.Open();
        }
        void CloseConnection()
        {
            conn.Close();
        }
        public DataTable LoadData(string sql, params SqlParameter[] sp)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(sp);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            CloseConnection();
            return dt;
        }
        public int Insert_Update_Delete(string sql, params SqlParameter[] spIns)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(spIns);
            int result = cmd.ExecuteNonQuery();
            CloseConnection();
            return result;

        }
        public int Execute(string sql, SqlParameter[] sp)
        {
            try
            {
                return Insert_Update_Delete(sql, sp);
            }
            catch (SqlException)
            {
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
