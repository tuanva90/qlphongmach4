using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
namespace BUS
{
    public class BenhNhanBUS
    {
        private BenhNhanDAO bndao = new BenhNhanDAO();
        private PhieuKhamBenhDAO pkbdao = new PhieuKhamBenhDAO();
        private HoaDonDAO hddao = new HoaDonDAO();
        public void showInListView(ListView lv, BenhNhanDTO[] listbn)
        {            
            if (lv.Items.Count > 0)
                lv.Items.Clear();
            if (listbn != null)
            {
                for (int i = 0; i < listbn.Length; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (i + 1).ToString();
                    lvi.SubItems.Add(listbn[i].MaBenhNhan.ToString());
                    lvi.SubItems.Add(listbn[i].HoTen.ToString());
                    lvi.SubItems.Add(listbn[i].GioiTinh.ToString());
                    lvi.SubItems.Add(listbn[i].NamSinh.ToString());
                    lvi.SubItems.Add(listbn[i].SoDienThoai.ToString());
                    lvi.SubItems.Add(listbn[i].DiaChi.ToString());
                    lv.Items.Add(lvi);
                }
            }
        }
        public void showBNChuaLapPhieuKham(ListView lv, BenhNhanDTO[] listbn, string ngaykham)
        {
            if (lv.Items.Count > 0)
                lv.Items.Clear();
            if (listbn != null)
            {
                for (int i = 0; i < listbn.Length; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (i + 1).ToString();
                    lvi.SubItems.Add(listbn[i].MaBenhNhan.ToString());
                    lvi.SubItems.Add(listbn[i].HoTen.ToString());
                    lvi.SubItems.Add(listbn[i].GioiTinh.ToString());
                    lvi.SubItems.Add(listbn[i].NamSinh.ToString());
                    lvi.SubItems.Add(listbn[i].SoDienThoai.ToString());
                    lvi.SubItems.Add(listbn[i].DiaChi.ToString());
                    if (pkbdao.getByPrimaryKey(listbn[i].MaBenhNhan.ToString() + ngaykham) == null)
                        lvi.BackColor = Color.Yellow;
                    lv.Items.Add(lvi);
                }
            }
        }
        public void showBNChuaLapHD(ListView lv, BenhNhanDTO[] listbn, string ngaykham)
        {
            if (lv.Items.Count > 0)
                lv.Items.Clear();
            if (listbn != null)
            {
                for (int i = 0; i < listbn.Length; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (i + 1).ToString();
                    lvi.SubItems.Add(listbn[i].MaBenhNhan.ToString());
                    lvi.SubItems.Add(listbn[i].HoTen.ToString());
                    lvi.SubItems.Add(listbn[i].GioiTinh.ToString());
                    lvi.SubItems.Add(listbn[i].NamSinh.ToString());
                    lvi.SubItems.Add(listbn[i].SoDienThoai.ToString());
                    lvi.SubItems.Add(listbn[i].DiaChi.ToString());
                    if(hddao.getByPrimaryKey(listbn[i].MaBenhNhan.ToString() + ngaykham)==null)
                        lvi.BackColor = Color.Yellow;
                    lv.Items.Add(lvi);
                }
            }
        }
        public string getMaBN()
        {
            return bndao.getMaBenhNhan();
        }
        public void showInListView(ListView lv, BenhNhanDTO bn)
        {           
            if (lv.Items.Count > 0)
                lv.Items.Clear();
            if (bn != null)
            {               
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (1).ToString();
                    lvi.SubItems.Add(bn.MaBenhNhan.ToString());
                    lvi.SubItems.Add(bn.HoTen.ToString());
                    lvi.SubItems.Add(bn.GioiTinh.ToString());
                    lvi.SubItems.Add(bn.NamSinh.ToString());
                    lvi.SubItems.Add(bn.SoDienThoai.ToString());
                    lvi.SubItems.Add(bn.DiaChi.ToString());
                    lv.Items.Add(lvi);            }
        }           
         public int insert(BenhNhanDTO bn)
        {
            int result=0;
            bn.MaBenhNhan = bndao.getMaBenhNhan();
            if (bn.HoTen == "" || bn.NamSinh == "" || bn.GioiTinh == "" || bn.DiaChi == "")
            {
                MessageBox.Show(" Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                try
                {
                    if (int.Parse(bn.NamSinh) < 1800 || int.Parse(bn.NamSinh) > 2012)
                        MessageBox.Show(" Năm sinh bệnh nhân không hợp lệ");
                    else
                    {
                        result = bndao.insert(bn);
                        if (result > 0)
                            MessageBox.Show(" Thêm bệnh nhân : " + bn.MaBenhNhan + " thành công !");
                        else
                            MessageBox.Show(" Thêm bệnh nhân : " + bn.MaBenhNhan + " thất bại !");
                    }
                }
                catch
                {
                    MessageBox.Show(" Năm sinh không hợp lệ !");
                }
            }
            return result;
        }
         public void update(BenhNhanDTO bn)
         {
             if (bn.HoTen == "" || bn.NamSinh == "" || bn.GioiTinh == "" || bn.DiaChi == "")
             {
                 MessageBox.Show(" Vui lòng nhập đầy đủ thông tin");
             }
             else
             {
                 if (int.Parse(bn.NamSinh) < 1800 || int.Parse(bn.NamSinh) > 2012)
                     MessageBox.Show(" Năm sinh bệnh nhân không hợp lệ");
                 else
                 {
                     int result = bndao.update(bn); 
                     if (result > 0)
                         MessageBox.Show(" Cập nhật thông tin bệnh nhân : " + bn.MaBenhNhan + " thành công !");
                     else
                         MessageBox.Show(" Cập nhật thông tin bệnh nhân : " + bn.MaBenhNhan + " thất bại !");
                 }
             }
            
         }

         public void delete(string mabn)
         {
             DialogResult result;
             result = MessageBox.Show("Bạn có thật sự muốn xóa bệnh nhân " + mabn + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (result == DialogResult.Yes)
             {
                 int result1 = bndao.delete(mabn);
                 if (result1 > 0)
                     MessageBox.Show(" Đã xóa bệnh nhân : " + mabn + " !");
                 else
                 {
                     if(result1==-2)
                         MessageBox.Show(" Không thể xóa bệnh nhân này vì ràng buộc khóa ngoại !");
                     MessageBox.Show(" Xóa thất bại !");
                 }
             }             
         }
        public BenhNhanDTO[]  getList()// list of all benhnhan
        {
            return bndao.getList();
        }
        public BenhNhanDTO[] getListByDSKB(string ngaykham, string option)// list of all benhnhan da co trong danh sach kham benh hay chua : option = in : da co trong dskb cua ngay, option = not in : chua co trong dskb trong ngay
        {
            return bndao.getListByDSKB(ngaykham, option);
        }
        public BenhNhanDTO[] getListByPhieuKham(string ngaykham, string option)// lay danh sach benh nhan co trong danh sach kham benh nhung chua duoc lap hoa don !
        {
            return bndao.getListByPhieuKham(ngaykham, option);
        }
        public BenhNhanDTO getByPrimaryKey(string mabn)
        {
            return bndao.getByPrimaryKey(mabn);
        }
        public BenhNhanDTO getByHoTen(string hoten)
        {
            return bndao.getByHoTen(hoten);
        }
    }
}
