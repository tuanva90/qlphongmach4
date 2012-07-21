using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data;
using System.Windows.Forms;
using DTO;
namespace BUS
{
   public class PhieuKhamBenhBUS
    {
        private PhieuKhamBenhDAO dvdao = new PhieuKhamBenhDAO();
        private LoaiBenhBUS lbbus = new LoaiBenhBUS();
        public void showPKByBenhNhan(ListView lv, string mabn)
        {
            PhieuKhamBenhDTO[] list = dvdao.getListByBenhNhan(mabn);
            if (lv.Items.Count > 0)
                lv.Items.Clear();
            if (list != null)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (i + 1).ToString();
                    lvi.SubItems.Add(list[i].NgayKham.ToString());
                    lvi.SubItems.Add(list[i].TrieuChung.ToString());
                    lvi.SubItems.Add(lbbus.getByPrimaryKey(int.Parse(list[i].MaLoaiBenh.ToString())).TenLoaiBenh.ToString());
                    lvi.SubItems.Add(lbbus.getByPrimaryKey(int.Parse(list[i].MaLoaiBenhPhu.ToString())).TenLoaiBenh.ToString());                   
                    lv.Items.Add(lvi);
                }
            }
        }
        public int insert(PhieuKhamBenhDTO bn)
        {
            if (((bn.MaLoaiBenh == bn.MaLoaiBenhPhu)&&bn.MaLoaiBenh!=1) || (bn.MaLoaiBenhPhu != 1 && bn.MaLoaiBenh == 1))
            {
                MessageBox.Show(" Lựa chọn loại bệnh và loại bệnh phụ chưa hợp lệ !");
                return 0;
            }
            else
            {               
                    bn.MaPhieuKhamBenh = bn.MaBenhNhan + bn.NgayKham;
                    int result = dvdao.insert(bn);
                    if (result > 0)
                        MessageBox.Show(" Lập phiếu khám bệnh thành công !");
                    else
                        MessageBox.Show(" Lập phiếu khám bệnh thất bại !");
                    return result;
            }
        }
        public void update(PhieuKhamBenhDTO bn)
        {
              DialogResult result1;
            result1 = MessageBox.Show("Bạn có thật sự sửa phiếu khám bệnh nàh ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                if (((bn.MaLoaiBenh == bn.MaLoaiBenhPhu) && bn.MaLoaiBenh != 1) || (bn.MaLoaiBenhPhu != 1 && bn.MaLoaiBenh == 1))
                {
                    MessageBox.Show(" Lựa chọn loại bệnh và loại bệnh phụ chưa hợp lệ !");
                                   }
                else
                {
                    bn.MaPhieuKhamBenh = bn.MaBenhNhan + bn.NgayKham;
                    int result = dvdao.update(bn);
                    if (result > 0)
                        MessageBox.Show(" Sửa phiếu khám bệnh thành công !");
                    else
                        MessageBox.Show(" Sửa phiếu khám bệnh thất bại !");                   
                }
            }
        }
        public PhieuKhamBenhDTO getByPrimaryKey(string mabenhnhan, string ngaykham)
        {
            return dvdao.getByPrimaryKey(mabenhnhan + ngaykham);
        }

        public void delete(int ma)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có thật sự muốn xóa phiếu khám này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int result1 = dvdao.delete(ma);
                if (result1 > 0)
                    MessageBox.Show(" Đã xóa!");
                else
                {
                    if (result1 == -2)
                        MessageBox.Show(" Không thể xóa vì ràng buộc khóa ngoại !");
                    MessageBox.Show(" Xóa thất bại !");
                }
            }
        }
        public PhieuKhamBenhDTO[] getListByNgayKham(string ngaykham)
        {
            return dvdao.getListByNgayKham(ngaykham);
        }
      
    }
}
