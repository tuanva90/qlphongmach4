using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;
using System.Data;
namespace DAO
{
    public class LoaiThuocDAO
    {
        private ConectData conectData = new ConectData();
        public int insert(LoaiThuocDTO cd)
        {
            string sql = "insert into LOAITHUOC values (@TenLoaiThuoc,@MaDonViTinh,@DonGia,@SoLuong)";
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@TenLoaiThuoc", cd.TenLoaiThuoc);
            sp[1] = new SqlParameter("@MaDonViTinh", cd.MaDonViTinh);
            sp[2] = new SqlParameter("@DonGia", cd.DonGia);
            sp[3] = new SqlParameter("@SoLuong", cd.SoLuong);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int update(LoaiThuocDTO cd)
        {
            string sql = "update LOAITHUOC set TenLoaiThuoc=@TenLoaiThuoc, MaDonViTinh=@MaDonViTinh, DonGia=@DonGia, SoLuong=@SoLuong where MaLoaiThuoc=@MaLoaiThuoc";
            SqlParameter[] sp = new SqlParameter[6];
            sp[0] = new SqlParameter("@TenLoaiThuoc", cd.TenLoaiThuoc);
            sp[1] = new SqlParameter("@MaDonViTinh", cd.MaDonViTinh);
            sp[2] = new SqlParameter("@DonGia", cd.DonGia);
            sp[3] = new SqlParameter("@SoLuong", cd.SoLuong);
            sp[4] = new SqlParameter("@MaLoaiThuoc", cd.MaLoaiThuoc);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int updateSoLuong(LoaiThuocDTO cd)
        {
            string sql = "update LOAITHUOC set SoLuong=@SoLuong where MaLoaiThuoc=@MaLoaiThuoc";
            SqlParameter[] sp = new SqlParameter[2];           
            sp[0] = new SqlParameter("@SoLuong", cd.SoLuong);
            sp[1] = new SqlParameter("@MaLoaiThuoc", cd.MaLoaiThuoc);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public int updateTenThuoc(LoaiThuocDTO cd)
        {
            string sql = "update LOAITHUOC set TenLoaiThuoc=@SoLuong, MaDonViTinh=@MaDonViTinh where MaLoaiThuoc=@MaLoaiThuoc";
            SqlParameter[] sp = new SqlParameter[3];
            sp[0] = new SqlParameter("@SoLuong", cd.TenLoaiThuoc);
            sp[1] = new SqlParameter("@MaDonViTinh", cd.MaDonViTinh);
            sp[2] = new SqlParameter("@MaLoaiThuoc", cd.MaLoaiThuoc);
            return conectData.Insert_Update_Delete(sql, sp);
        }
        public LoaiThuocDTO[] getList()// list of all loaithuoc
        {
            LoaiThuocDTO[] list;
            string sql = " select * from LOAITHUOC ";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new LoaiThuocDTO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list[i] = new LoaiThuocDTO();
                    list[i].MaLoaiThuoc = int.Parse(dt.Rows[i]["MaLoaiThuoc"].ToString());
                    list[i].TenLoaiThuoc = dt.Rows[i]["TenLoaiThuoc"].ToString();
                    list[i].MaDonViTinh = int.Parse(dt.Rows[i]["MaDonViTinh"].ToString());
                    list[i].DonGia= float.Parse(dt.Rows[i]["DonGia"].ToString());
                    try
                    {
                        list[i].SoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                    }
                    catch
                    {
                        list[i].SoLuong=0;
                    }                  

                }
            }
            return list;
        }
        public LoaiThuocDTO[] getBaoCaoThuocTheoNgay(string ngaybaocao)// list of all loaithuoc
        {
            LoaiThuocDTO[] list;
            string sql = " select ctk.MaLoaiThuoc ,sum(ctk.SoLuong) as SoLuong from CT_KHAM ctk, HOADON hd";
            sql += " where ctk.MaPhieuKhamBenh=hd.MaPhieuKhamBenh and hd.TienThuoc>0 and substring(ctk.MaPhieuKhamBenh,6,10)=@ngay group by ctk.MaLoaiThuoc order by SoLuong DESC ";
            DataTable dt = new DataTable();
            SqlParameter sp = new SqlParameter("@ngay", ngaybaocao);
            dt = conectData.LoadData(sql,sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new LoaiThuocDTO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list[i] = new LoaiThuocDTO();
                    list[i].MaLoaiThuoc = int.Parse(dt.Rows[i]["MaLoaiThuoc"].ToString());                 
                     list[i].SoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());                    
                }
            }
            return list;
        }
        public LoaiThuocDTO[] getBaoCaoThuocTheoThang(int thang, int nam)// list of all loaithuoc
        {
            LoaiThuocDTO[] list;
            string sql = " select ctk.MaLoaiThuoc ,sum(ctk.SoLuong) as SoLuong from CT_KHAM ctk, HOADON hd";
            sql += " where ctk.MaPhieuKhamBenh=hd.MaPhieuKhamBenh and hd.TienThuoc>0 and left(Substring(hd.MaPhieuKhamBenh,6,10),Charindex('/',Substring(hd.MaPhieuKhamBenh,6,10),0)-1)=@thang and right(Substring(hd.MaPhieuKhamBenh,6,10),4)=@nam group by ctk.MaLoaiThuoc order by SoLuong DESC ";
            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@thang", thang);
            sp[1] = new SqlParameter("@nam", nam);
            dt = conectData.LoadData(sql, sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                list = new LoaiThuocDTO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list[i] = new LoaiThuocDTO();
                    list[i].MaLoaiThuoc = int.Parse(dt.Rows[i]["MaLoaiThuoc"].ToString());
                    list[i].SoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                }
            }
            return list;
        }
        public LoaiThuocDTO getByPrimaryKey(int maloaithuoc)// list of all benhnhan
        {
            LoaiThuocDTO loaithuoc = new LoaiThuocDTO();
            string sql = " select * from LOAITHUOC Where MaLoaiThuoc=@MaLoaiThuoc ";
            SqlParameter sp = new SqlParameter("@MaLoaiThuoc", maloaithuoc);
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql,sp);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                loaithuoc.MaLoaiThuoc = int.Parse(dt.Rows[0]["MaLoaiThuoc"].ToString());
                loaithuoc.TenLoaiThuoc = dt.Rows[0]["TenLoaiThuoc"].ToString();
                loaithuoc.MaDonViTinh = int.Parse(dt.Rows[0]["MaDonViTinh"].ToString());
                loaithuoc.DonGia = float.Parse(dt.Rows[0]["DonGia"].ToString());
                loaithuoc.SoLuong = float.Parse(dt.Rows[0]["SoLuong"].ToString());              

            }
            return loaithuoc;
        }
        public int delete(int magv)
        {
            string sql;
            int result;
            SqlParameter sp;
            try
            {
                sql = "delete from LOAITHUOC where MaLoaiThuoc=@MaLoaiThuoc";
                sp = new SqlParameter("@MaLoaiThuoc", magv);
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
