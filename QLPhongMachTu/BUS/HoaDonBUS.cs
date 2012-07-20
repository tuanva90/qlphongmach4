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
    }
}
