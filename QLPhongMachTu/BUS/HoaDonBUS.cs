using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data;
using System.Windows.Forms;
namespace BUS
{
   public class HoaDonBUS
    {
       HoaDonDAO dao = new HoaDonDAO();
       public void showByBenhNhan(ListView lv,string mabn)
       {
           HoaDonDTO[] list = dao.getLisByBenhNhan(mabn);
           if (lv.Items.Count > 0)
               lv.Items.Clear();
           if (list != null)
           {
               for (int i = 0; i < list.Length; i++)
               {
                   ListViewItem lvi = new ListViewItem();
                   lvi.Text = (i + 1).ToString();
                   if (list[i].MaPhieuKhamBenh.Length == 15)
                   {
                       lvi.SubItems.Add(list[i].MaPhieuKhamBenh.Substring(5, 10).ToString());
                   }
                   else
                       lvi.SubItems.Add(list[i].MaPhieuKhamBenh.Substring(5, 9).ToString());
                   lvi.SubItems.Add(list[i].TienKham.ToString());
                   lvi.SubItems.Add(list[i].TienThuoc.ToString());
                   lv.Items.Add(lvi);
               }
           }
       }
       public int insert(HoaDonDTO hd)
       {          
               int result = dao.insert(hd);
               if (result > 0)
               {
                   MessageBox.Show(" Lập hóa đơn thành công !");
               }
               else
               {
                   if (result == -2)
                       MessageBox.Show(" Hóa đơn này đã được lập !");
                   else
                       MessageBox.Show(" Lập hóa đơn thất bại !");
               }
               return result;
       }
       public HoaDonDTO getByPrimaryKey(string maphieukhambenh)
       {
           return dao.getByPrimaryKey(maphieukhambenh);
       }
       public HoaDonDTO[] getBaoCaoThang(int thang, int nam)
       {
           return dao.getBaoCaoThang(thang, nam);
       }
    }
}
