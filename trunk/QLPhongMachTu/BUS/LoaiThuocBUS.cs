using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;
using System.Data;
using System.Windows.Forms;

namespace BUS
{
    public class LoaiThuocBUS
    {
        private LoaiThuocDAO dao = new LoaiThuocDAO();
        public void showInListView(ListView lv)
        {
            LoaiThuocDTO[] list = dao.getList();
            if (lv.Items.Count > 0)
                lv.Items.Clear();
            if (list != null || list.Length == 0)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (i + 1).ToString();
                    lvi.SubItems.Add(list[i].TenLoaiThuoc.ToString());
                    lvi.SubItems.Add(list[i].MaLoaiThuoc.ToString());
                    lv.Items.Add(lvi);
                }
            }
        }
        public void insert(LoaiThuocDTO dto)
        {
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
                        if (dto.TenLoaiThuoc.Equals(dv[i].TenLoaiThuoc.ToString()))
                        {
                            check = true;
                            break;
                        }
                    }
                    if (check != true)
                    {
                        int result = dao.insert(dto);
                        if (result > 0)
                            MessageBox.Show(" Thêm loại thuốc thành công !");
                        else
                            MessageBox.Show(" Thêm loại thuốc thất bại !");
                    }
                    else
                        MessageBox.Show(" Tên đơn loại thuốc đã tồn tại !");
                }
                else
                {
                    int result = dao.insert(dto);
                    if (result > 0)
                        MessageBox.Show(" Thêm loại thuốc thành công !");
                    else
                        MessageBox.Show(" Thêm loại thuốc  thất bại !");
                }
            }
        }
        public void update(LoaiThuocDTO dto)
        {
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
                        if (dto.TenLoaiThuoc == (dv[i].TenLoaiThuoc.ToString()))
                        {
                            check = true;
                            break;
                        }
                    }
                    if (check != true)
                    {
                        int result = dao.update(dto);
                        if (result > 0)
                            MessageBox.Show(" Cập nhật thông tin loại thuốc thành công !");
                        else
                            MessageBox.Show(" Cập nhật thông tin loại thuốc thất bại !");
                    }
                    else
                        MessageBox.Show(" Tên đơn loại thuốc đã tồn tại !");
                }
                else
                {
                    int result = dao.update(dto);
                    if (result > 0)
                        MessageBox.Show(" Cập nhật thông tin loại thuốc thành công !");
                    else
                        MessageBox.Show(" Cập nhật thông tin loại thuốc thất bại !");
                }
            }

        }

        public void delete(int ma)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có thật sự muốn xóa loại thuốc này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int result1 = dao.delete(ma);
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
        public LoaiThuocDTO[] getList()
        {
            return dao.getList();
        }
          public LoaiThuocDTO getByPrimaryKey(int mathuoc)
        {
            return dao.getByPrimaryKey(mathuoc);
        }
    }
}
