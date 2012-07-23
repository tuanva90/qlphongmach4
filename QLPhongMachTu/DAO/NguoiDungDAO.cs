using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class NguoiDungDAO
    {
        private ConectData conectData = new ConectData();
        public int insert(NguoiDungDTO nd)
        {
            string sql = "insert into USERS values (@TenUser,@MatKhau,@MaPhanQuyen)";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@TenUser", nd.TenDangNhap);
            sp[1] = new SqlParameter("@MatKhau", nd.MatKhau);
            sp[2] = new SqlParameter("@MaPhanQuyen", nd.MaPhanQuyen);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int update(NguoiDungDTO nd)
        {
            string sql = "update USERS set MatKhau=@MatKhau, MaPhanQuyen=@MaPhanQuyen where MaUser=@MaUser";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@MatKhau", nd.MatKhau);
            sp[1] = new SqlParameter("@MaPhanQuyen", nd.MaPhanQuyen);
            sp[2] = new SqlParameter("@MaUser", nd.MaNguoiDung);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int delete(int ma)
        {
            string sql;
            int result;
            SqlParameter sp;
            try
            {
                sql = "delete from USERS where MaUser=@MaUser";
                sp = new SqlParameter("@MaUser", ma);
                result = conectData.Insert_Update_Delete(sql, sp);
            }
            catch (Exception ex)
            {
                return -2; // can't delte this CachDung, if this CachDung is not a primary key of any table =>> return -1;
            }
            return result;
        }
        public NguoiDungDTO getByPrimaryKey(int maNguoiDung)
        {
            NguoiDungDTO nd = new NguoiDungDTO();
            string sql = " select * from USERS  where MaUser=@MaUser";
            SqlParameter sp = new SqlParameter("@MaUser", maNguoiDung);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {

                nd.MaNguoiDung = int.Parse(dt.Rows[0]["MaUser"].ToString());
                nd.TenDangNhap = dt.Rows[0]["TenUser"].ToString();
                nd.MatKhau = dt.Rows[0]["MatKhau"].ToString();
                nd.MaPhanQuyen = int.Parse(dt.Rows[0]["MaPhanQuyen"].ToString());
            }
            return nd;
        }

        public NguoiDungDTO getByTenDangNhap(string tenDangNhap)
        {
            NguoiDungDTO nd = new NguoiDungDTO();
            string sql = " select * from USERS  where TenUser=@TenUser";
            SqlParameter sp = new SqlParameter("@TenUser", tenDangNhap);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {

                nd.MaNguoiDung = int.Parse(dt.Rows[0]["MaUser"].ToString());
                nd.TenDangNhap = dt.Rows[0]["TenUser"].ToString();
                nd.MatKhau = dt.Rows[0]["MatKhau"].ToString();
                nd.MaPhanQuyen = int.Parse(dt.Rows[0]["MaPhanQuyen"].ToString());
            }
            return nd;
        }

        public bool CheckExist(string tenDangNhap)
        {
            NguoiDungDTO[] list = getList();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].TenDangNhap.ToUpper().Equals(tenDangNhap.ToUpper()))
                    return true;
            }
            return false;
        }

        public bool CheckLogin(string tenDangNhap, string matkhau)
        {
            string sql = "select * from USERS where TenUser=@TenUser AND MatKhau=@MatKhau";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@TenUser", tenDangNhap);
            sp[1] = new SqlParameter("@MatKhau", matkhau);
            DataTable dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return false;
            return true;
        }

        public NguoiDungDTO[] getList()// list of all NguoiDung
        {
            NguoiDungDTO[] list;
            string sql = " select * from USERS";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new NguoiDungDTO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list[i] = new NguoiDungDTO();
                    list[i].MaNguoiDung = int.Parse(dt.Rows[i]["MaUser"].ToString());
                    list[i].TenDangNhap = dt.Rows[i]["TenUser"].ToString();
                    list[i].MatKhau = dt.Rows[i]["MatKhau"].ToString();
                    list[i].MaPhanQuyen = int.Parse(dt.Rows[i]["MaPhanQuyen"].ToString());
                }
            }
            return list;
        }
    }
}
