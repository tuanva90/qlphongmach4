using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
   public class BenhNhanDAO
    {
       private ConectData conectData = new ConectData();
        string magv;
            
        public string getMaBenhNhan() // lay ma giao vien
        {
            string sql = " SELECT MAX(cast(substring(MaBenhNhan,3,3) as int)) FROM BENHNHAN";
            DataTable dt = new DataTable();
            dt = conectData.LoadData(sql);
            if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == "NULL")
            {
                magv = "001";
            }
            else
            {
                int s = int.Parse(dt.Rows[0][0].ToString()) + 1;
                if (s < 10)
                    magv = "00" + s.ToString();
                else
                {
                    if (s < 100)
                        magv = "0" + s.ToString();
                    else
                    {
                        if (s < 1000)
                            magv = s.ToString();

                    }

                }
            }
            return "BN" + magv;        
         }

       public int insert(BenhNhanDTO bn)
       {
           string sql = "insert into BENHNHAN values (@MaBenhNhan,@HoTen,@GioiTinh,@NamSinh,@DiaChi,@SoDienThoai)";
           SqlParameter[] sp = new SqlParameter[6];
           sp[0] = new SqlParameter("@MaBenhNhan", bn.MaBenhNhan);
           sp[1] = new SqlParameter("@HoTen", bn.HoTen);
           sp[2] = new SqlParameter("@GioiTinh",bn.GioiTinh);
           sp[3] = new SqlParameter("@Namsinh",bn.NamSinh);
           sp[4] = new SqlParameter("@DiaChi", bn.DiaChi);
           sp[5] = new SqlParameter("@SoDienThoai", bn.SoDienThoai);          
           return conectData.Insert_Update_Delete(sql, sp);
       }
       public int update(BenhNhanDTO bn)
       {
           string sql = "update BenhNhan set HoTen=@HoTen, GioiTinh=@GioiTinh, NamSinh=@NamSinh, DiaChi=@DiaChi, SoDienThoai=@SoDienThoai WHERE MaBenhNhan=@MaBenhNhan";
           SqlParameter[] sp = new SqlParameter[6];
           sp[0] = new SqlParameter("@MaBenhNhan", bn.MaBenhNhan);
           sp[1] = new SqlParameter("@HoTen", bn.HoTen);
           sp[2] = new SqlParameter("@GioiTinh", bn.GioiTinh);
           sp[3] = new SqlParameter("@Namsinh", bn.NamSinh);
           sp[4] = new SqlParameter("@DiaChi", bn.DiaChi);
           sp[5] = new SqlParameter("@SoDienThoai", bn.SoDienThoai);
           return conectData.Insert_Update_Delete(sql, sp);
       }
       public BenhNhanDTO getByPrimaryKey(string mabn)
       {
           BenhNhanDTO bn = new BenhNhanDTO();
           string sql = " select * from BENHNHAN  where MaBenhNhan =@magv";
           SqlParameter sp = new SqlParameter("@magv", mabn);
           DataTable dt = conectData.LoadData(sql, sp);
           if (dt == null || dt.Rows.Count==0)
               return null;
           else
           {
               bn.MaBenhNhan = dt.Rows[0]["MaBenhNhan"].ToString();
               bn.HoTen = dt.Rows[0]["HoTen"].ToString();
               bn.GioiTinh = dt.Rows[0]["GioiTinh"].ToString();
               bn.NamSinh = dt.Rows[0]["NamSinh"].ToString();
               bn.DiaChi = dt.Rows[0]["DiaChi"].ToString();
               bn.SoDienThoai = dt.Rows[0]["SoDienThoai"].ToString();
           }
           return bn;
       }
       public BenhNhanDTO getByHoTen(string hoten)
       {
           BenhNhanDTO bn = new BenhNhanDTO();
           string sql = " select * from BENHNHAN  where HoTen like @magv";
           SqlParameter sp = new SqlParameter("@magv", "%" + hoten + "%");
           DataTable dt = conectData.LoadData(sql, sp);
           if (dt == null || dt.Rows.Count==0)
               return null;
           else
           {
               bn.MaBenhNhan = dt.Rows[0]["MaBenhNhan"].ToString();
               bn.HoTen = dt.Rows[0]["HoTen"].ToString();
               bn.GioiTinh = dt.Rows[0]["GioiTinh"].ToString();
               bn.NamSinh = dt.Rows[0]["NamSinh"].ToString();
               bn.DiaChi = dt.Rows[0]["DiaChi"].ToString();
               bn.SoDienThoai = dt.Rows[0]["SoDienThoai"].ToString();
           }
           return bn;
       }
       public BenhNhanDTO[]  getList()// list of all benhnhan
       {
           BenhNhanDTO[] list;
           string sql = "select * from BENHNHAN";    
           DataTable dt = new DataTable();
           dt = conectData.LoadData(sql);
           if (dt == null || dt.Rows.Count == 0)
               return null;
           else
           {
                list = new BenhNhanDTO[dt.Rows.Count];
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   list[i] = new BenhNhanDTO();
                   list[i].MaBenhNhan =  dt.Rows[i]["MaBenhNhan"].ToString();
                   list[i].HoTen =  dt.Rows[i]["HoTen"].ToString();
                   list[i].GioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                   list[i].NamSinh = dt.Rows[i]["NamSinh"].ToString();
                   list[i].DiaChi = dt.Rows[i]["DiaChi"].ToString();
                   list[i].SoDienThoai = dt.Rows[i]["SoDienThoai"].ToString();
               }
           }
           return list;

       }
       public BenhNhanDTO[] getListByDSKB(string ngaykham, string optinon)// list of all benhnhan theo danh sach ( da duoc dua vao or chua duoc dua vao ) kham benh trong ngay
       {
           BenhNhanDTO[] list;
           string sql = "select * from BENHNHAN where MaBenhNhan " + optinon + " (select MaBenhNhan from DANHSACHKHAMBENH where NgayKham=@NgayKham)";
           DataTable dt = new DataTable();
           SqlParameter sp = new SqlParameter("@NgayKham", ngaykham);
           dt = conectData.LoadData(sql,sp);
           if (dt == null || dt.Rows.Count == 0)
               return null;
           else
           {
               list = new BenhNhanDTO[dt.Rows.Count];
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   list[i] = new BenhNhanDTO();
                   list[i].MaBenhNhan = dt.Rows[i]["MaBenhNhan"].ToString();
                   list[i].HoTen = dt.Rows[i]["HoTen"].ToString();
                   list[i].GioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                   list[i].NamSinh = dt.Rows[i]["NamSinh"].ToString();
                   list[i].DiaChi = dt.Rows[i]["DiaChi"].ToString();
                   list[i].SoDienThoai = dt.Rows[i]["SoDienThoai"].ToString();
               }
           }
           return list;
       }
       public int delete(string magv)
       {
           string sql;
           int result;
           SqlParameter sp;
           try
           {
               sql = "delete from BENHNHAN where MaBenhNhan=@MaBenhNhan";
               sp = new SqlParameter("@MaBenhNhan", magv);
               result = conectData.Insert_Update_Delete(sql, sp);
           }
           catch (Exception ex)
           {
               return -2; // can't delte this BenhNhan, if this CachDung is not a primary key of any table =>> return -1;
           }
           return result;

       }

    }
}
