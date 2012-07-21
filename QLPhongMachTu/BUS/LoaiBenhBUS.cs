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
   public class LoaiBenhBUS
    {
        private LoaiBenhDAO dao = new LoaiBenhDAO();
        public void showInListView(ListView lv)
        {
            LoaiBenhDTO[] list = dao.getList();
            if (lv.Items.Count > 0)
                lv.Items.Clear();
            if (list != null)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (i + 1).ToString();
                    lvi.SubItems.Add(list[i].TenLoaiBenh.ToString());
                    lvi.SubItems.Add(list[i].MaLoaiBenh.ToString());
                    lv.Items.Add(lvi);
                }
            }
        }
        public void insert(LoaiBenhDTO dto)
        {
            if (dto.TenLoaiBenh == "")
            {
                MessageBox.Show(" Nhập tên loại bệnh !");
            }
            else
            {
                LoaiBenhDTO[] dv = dao.getList();
                if (dv != null || dv.Length == 0)
                {
                    bool check = false; // kieim tra trung ten
                    for (int i = 0; i < dv.Length; i++)
                    {
                        if (string.Equals(dto.TenLoaiBenh,dv[i].TenLoaiBenh.ToString()))
                        {
                            check = true;
                            break;
                        }
                    }
                    if (check != true)
                    {
                        int result = dao.insert(dto);
                        if (result > 0)
                            MessageBox.Show(" Thêm loại bệnh thành công !");
                        else
                            MessageBox.Show(" Thêm loại bệnh thất bại !");
                    }
                    else
                        MessageBox.Show(" Tên đơn loại bệnh đã tồn tại !");
                }
                else
                {
                    int result = dao.insert(dto);
                    if (result > 0)
                        MessageBox.Show(" Thêm loại bệnh thành công !");
                    else
                        MessageBox.Show(" Thêm loại bệnh  thất bại !");
                }
            }
        }
        public void update(LoaiBenhDTO dto)
        {
            if (dto.MaLoaiBenh == 1)
            {
                MessageBox.Show(" Đây là giá trị mặc định để xác định bệnh nhân không bị bệnh, không thể xóa hoặc sửa !");
            }
            else
            {
                if (dto.TenLoaiBenh == "")
                {
                    MessageBox.Show(" Nhập tên loại bệnh !");
                }
                else
                {
                    LoaiBenhDTO[] dv = dao.getList();
                    if (dv != null || dv.Length == 0)
                    {
                        bool check = false; // kieim tra trung ten
                        for (int i = 0; i < dv.Length; i++)
                        {
                            if (string.Equals(dto.TenLoaiBenh,dv[i].TenLoaiBenh.ToString()))
                            {
                                check = true;
                                break;
                            }
                        }
                        if (check != true)
                        {
                            int result = dao.update(dto);
                            if (result > 0)
                                MessageBox.Show(" Cập nhật thông tin loại bệnh thành công !");
                            else
                                MessageBox.Show(" Cập nhật thông tin loại bệnh thất bại !");
                        }
                        else
                            MessageBox.Show(" Tên đơn loại bệnh đã tồn tại !");
                    }
                    else
                    {
                        int result = dao.update(dto);
                        if (result > 0)
                            MessageBox.Show(" Cập nhật thông tin loại bệnh thành công !");
                        else
                            MessageBox.Show(" Cập nhật thông tin loại bệnh thất bại !");
                    }
                }
            }

        }
        public LoaiBenhDTO getByPrimaryKey(int ma)
        {
            return dao.getByPrimaryKey(ma);
        }
        public void delete(int ma)
        {
            DialogResult result;
            if (ma == 1)
            {
                MessageBox.Show(" Đây là giá trị mặc định để xác định bệnh nhân không bị bệnh, không thể xóa hoặc sửa !");
            }
            else
            {
                result = MessageBox.Show("Bạn có thật sự muốn xóa loại bệnh này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
        }
        public LoaiBenhDTO[] getList()
        {
            return dao.getList();
        }
    }
}
