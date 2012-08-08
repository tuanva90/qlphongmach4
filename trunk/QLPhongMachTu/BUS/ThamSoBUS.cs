using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;
using System.Windows.Forms;
namespace BUS
{
   public class ThamSoBUS
    {
       public ThamSoDAO tsdao = new ThamSoDAO();
       public ThamSoDTO getThamSo()
       {           
           return tsdao.getThamSo();
       }
       public int updateSLTD(int isltd)
       {
           int ikq = -1;
           if (isltd > 0)
           {
               ikq = tsdao.update(isltd);
               if (ikq > 0)
                   MessageBox.Show("Cap nhat thanh cong");
               else
                   MessageBox.Show("Loi xay ra trong qua trinh cap nhat", "Loi");
               return ikq;
           }
           else
               MessageBox.Show("Du lieu khong phu hop, lam on nhap lai", "Loi du lieu");
           return -1;
       }
       public int updateTienKham(float dlTienKham)
       {
           int ikq = -1;
           if (dlTienKham > 0)
           {
               ikq = tsdao.update(dlTienKham);
               if (ikq > 0)
                   MessageBox.Show("Cap nhat thanh cong");
               else
                   MessageBox.Show("Loi xay ra trong qua trinh cap nhat", "Loi");
               return ikq;
           }
           else
               MessageBox.Show("Du lieu khong phu hop, lam on nhap lai", "Loi du lieu");
           return -1;
       }
    }
}
