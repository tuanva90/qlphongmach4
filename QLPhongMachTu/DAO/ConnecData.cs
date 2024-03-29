﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAO
{
    public class ConectData
    {
        //string connection = @"Data Source=.\SQLEXPRESS;AttachDbFilename='D:\study\ky 7\Phan mem huong doi tuong\SVN source\QLPhongMachTu\QLPhongMachTu\Database\PhongMachTu.mdf';Integrated Security=True;User Instance=True";
         //string str1 = Application.StartupPath + @"\PhongMachTu.mdf"; // Path.GetFullPath("QLPhongMachTu.mdf");
        //   string connection = @" Data Source=.\SQLEXPRESS;AttachDbFilename=" + str1 + ";Integrated Security=True;Connect Timeout=30;User Instance=True";

        string str1 = Application.StartupPath + @"\Database\PhongMachTu.mdf"; // Path.GetFullPath("QLPhongMachTu.mdf");
            //string str1 = @"Data Source=THANHIT-PC\SQLEXPRESS;Initial Catalog=QLPhongMachTu;Integrated Security=True";
        string connection;// = @" Data Source=.\SQLEXPRESS;AttachDbFilename=" + str1 + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
            
        SqlConnection conn;
        void OpenConnection()
        {
            connection = @" Data Source=.\SQLEXPRESS;AttachDbFilename=" + str1 + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
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
        public DataSet LoadData_dataset(string sql, params SqlParameter[] sp)
        {
            OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand secmd = new SqlCommand(sql, conn);
            secmd.Parameters.AddRange(sp);
            da.SelectCommand = secmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "mh");
            return ds;
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
