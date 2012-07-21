using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace BUS
{
    public class LoaiThuocBUS
    {
        private LoaiThuocDAO dao = new LoaiThuocDAO();
        private DonViDAO dvdao = new DonViDAO();
        private NhapKhoDAO nkdao = new NhapKhoDAO();
        public void showInListView(ListView lv)
        {
            LoaiThuocDTO[] list = dao.getList();
            if (lv.Items.Count > 0)
                lv.Items.Clear();
            if (list != null)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (i + 1).ToString();
                    lvi.SubItems.Add(list[i].MaLoaiThuoc.ToString());
                    lvi.SubItems.Add(list[i].TenLoaiThuoc.ToString());
                    lvi.SubItems.Add(dvdao.getByPrimaryKey(int.Parse(list[i].MaDonViTinh.ToString())).DonViTinh.ToString());
                    lvi.SubItems.Add(list[i].SoLuong.ToString());
                    lvi.SubItems.Add(list[i].DonGia.ToString());
                    if (float.Parse(list[i].SoLuong.ToString()) == 0)
                    {
                        lvi.BackColor = Color.Red;
                    }
                    else
                    {
                        if (float.Parse(list[i].SoLuong.ToString()) < 10)
                        {
                            lvi.BackColor = Color.Yellow;
                        }
                    }
                    lv.Items.Add(lvi);
                }
            }
        }
        public void showBaoCaoThuocTheoNgay(ListView lv,string ngay)
        {
            LoaiThuocDTO[] list = dao.getBaoCaoThuocTheoNgay(ngay);
            if (lv.Items.Count > 0)
                lv.Items.Clear();
            if (list != null)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                             lvi.Text = (i + 1).ToString();
                    lvi.SubItems.Add(list[i].MaLoaiThuoc.ToString());
                    int mathuoc = int.Parse(list[i].MaLoaiThuoc.ToString());
                    lvi.SubItems.Add(dao.getByPrimaryKey(mathuoc).TenLoaiThuoc.ToString());
                    lvi.SubItems.Add(dvdao.getByPrimaryKey(int.Parse(dao.getByPrimaryKey(mathuoc).MaDonViTinh.ToString())).DonViTinh.ToString());
                    lvi.SubItems.Add(list[i].SoLuong.ToString() + "/" + dao.getByPrimaryKey(mathuoc).SoLuong.ToString());                   
                    if (i<6)
                    {
                        lvi.BackColor = Color.SpringGreen;
                    }
                  
                    lv.Items.Add(lvi);
                }
            }
        }
        public void showBaoCaoThang(ListView lv, int thang, int nam)
        {
            LoaiThuocDTO[] list = dao.getBaoCaoThuocTheoThang(thang,nam);
            if (lv.Items.Count > 0)
                lv.Items.Clear();
            if (list != null)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (i + 1).ToString();
                    lvi.SubItems.Add(list[i].MaLoaiThuoc.ToString());
                    int mathuoc = int.Parse(list[i].MaLoaiThuoc.ToString());
                    lvi.SubItems.Add(dao.getByPrimaryKey(mathuoc).TenLoaiThuoc.ToString());
                    lvi.SubItems.Add(dvdao.getByPrimaryKey(int.Parse(dao.getByPrimaryKey(mathuoc).MaDonViTinh.ToString())).DonViTinh.ToString());
                    lvi.SubItems.Add(list[i].SoLuong.ToString() + "/" + dao.getByPrimaryKey(mathuoc).SoLuong.ToString());
                    if (i < 10)
                    {
                        lvi.BackColor = Color.SpringGreen;
                    }

                    lv.Items.Add(lvi);
                }
            }
        }
        public void nhapkho(NhapKhoDTO nk)
        {
            int result1 = 0;
            DialogResult result;
            result = MessageBox.Show("Bạn có chắc chắn muốn nhập kho loại thuốc này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                result1 = nkdao.insert(nk);
                if (result1 > 0)
                {                    MessageBox.Show(" Nhập kho thành công!");                    
                }

                else
                {
                    MessageBox.Show(" Nhập kho thất bại !");
                }
            }          
        }
        public int insert(LoaiThuocDTO dto)
        {
            int result = 0;
            if (dto.TenLoaiThuoc == "")
            {
                MessageBox.Show(" Nhập tên loại thuốc !");
            }
            else
            {
                LoaiThuocDTO[] dv = dao.getList();
                if (dv != null || dv.Length == 0)
                {
                    bool check = false; // kieim tra trung ten
                    for (int i = 0; i < dv.Length; i++)
                    {
                        if (string.Equals(dto.TenLoaiThuoc,dv[i].TenLoaiThuoc.ToString()))
                        {
                            check = true;
                            break;
                        }
                    }
                    if (check != true)
                    {
                         result = dao.insert(dto);
                        if (result > 0)
                            MessageBox.Show(" Thêm loại thuốc thành công !");
                        else
                            MessageBox.Show(" Thêm loại thuốc thất bại !");
                    }
                    else
                        MessageBox.Show(" Tên  loại thuốc đã tồn tại !");
                }
                else
                {
                    result = dao.insert(dto);
                    if (result > 0)
                        MessageBox.Show(" Thêm loại thuốc thành công !");
                    else
                        MessageBox.Show(" Thêm loại thuốc  thất bại !");
                }
            }
            return result;
        }
        public void updateSoLuong(LoaiThuocDTO ltdto)
        {
            try
            {
                int n = dao.updateSoLuong(ltdto);
            }
            catch
            {
                MessageBox.Show("Không thể cập nhật số lượng thuốc ");
            }
        }

        public int update(LoaiThuocDTO dto)
        {
            int result = 0;
            if (dto.TenLoaiThuoc == "")
            {
                MessageBox.Show(" Nhập tên loại thuốc !");
            }
            else
            {
                if (dao.getByPrimaryKey(dto.MaLoaiThuoc).TenLoaiThuoc.ToString().Equals(dto.TenLoaiThuoc.ToString()))
                {
                    MessageBox.Show(" Tên thuốc không thay đổi !");
                }
                else
                {
                    LoaiThuocDTO[] dv = dao.getList();
                    if (dv != null || dv.Length == 0)
                    {
                        bool check = false; // kieim tra trung ten
                        for (int i = 0; i < dv.Length; i++)
                        {
                            if (dto.TenLoaiThuoc == (dv[i].TenLoaiThuoc.ToString()))
                            {
                                check = true;
                                break;
                            }
                        }
                        if (check != true)
                        {
                           result = dao.updateTenThuoc(dto);
                            if (result > 0)
                                MessageBox.Show(" Cập nhật thông tin loại thuốc thành công !");
                            else
                                MessageBox.Show(" Cập nhật thông tin loại thuốc thất bại !");
                        }
                        else
                        {

                            MessageBox.Show(" Tên loại thuốc đã tồn tại !");
                        }
                    }
                    else
                    {
                        result = dao.updateTenThuoc(dto);
                        if (result > 0)
                            MessageBox.Show(" Cập nhật thông tin loại thuốc thành công !");
                        else
                            MessageBox.Show(" Cập nhật thông tin loại thuốc thất bại !");
                    }
                }
            }
            return result;
        }

        public int delete(int ma)
        {
            int result1=0;
            DialogResult result;
            result = MessageBox.Show("Bạn có thật sự muốn xóa loại thuốc này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                result1 = dao.delete(ma);
                if (result1 > 0)
                    MessageBox.Show(" Đã xóa!");
                else
                {
                    if (result1 == -2)
                        MessageBox.Show(" Không thể xóa vì ràng buộc khóa ngoại !");
                    MessageBox.Show(" Xóa thất bại !");
                }
            }
            return result1;
        }
        public LoaiThuocDTO[] getList()
        {
            return dao.getList();
        }
          public LoaiThuocDTO getByPrimaryKey(int mathuoc)
        {
            return dao.getByPrimaryKey(mathuoc);
        }
          public int getMaxLanNhap(int mathuoc)
          {
              return nkdao.getMaxLanNhap(mathuoc);
          }
    }
}
