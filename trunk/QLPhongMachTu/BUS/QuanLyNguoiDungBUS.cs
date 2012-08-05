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
    public class QuanLyNguoiDungBUS
    {
        private NguoiDungDAO dao = new NguoiDungDAO();
        private PhanQuyenDAO pqdao = new PhanQuyenDAO();
        public void showInListView(ListView lv)
        {
            NguoiDungDTO[] list = dao.getList();
            if (lv.Items.Count > 0)
                lv.Items.Clear();
            if (list != null)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (i + 1).ToString();
                    lvi.SubItems.Add(list[i].TenDangNhap.ToString());
                    lvi.SubItems.Add(pqdao.getTenPhanQuyenFromMaPhanQuyen(list[i].MaPhanQuyen));
                    lv.Items.Add(lvi);
                }
            }
        }

        public void showPhanQuyen(ComboBox cb)
        {
            PhanQuyenDTO[] list = pqdao.getList();
            if (list != null)
            {
                // do du lieu len commbobox
                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = pqdao.getList();
                cb.DataSource = bindingSource1.DataSource;
                cb.DisplayMember = "TenPhanQuyen";
                cb.ValueMember = "MaPhanQuyen";
            }
        }
        public void insert(NguoiDungDTO dto)
        {
            if (dto.TenDangNhap == "")
            {
                MessageBox.Show("Chưa nhập tên đăng nhập !");
            }
            else
            {

                if (dao.CheckExist(dto.TenDangNhap) != true)
                {
                    int result = dao.insert(dto);
                    if (result > 0)
                        MessageBox.Show(" Thêm thành công !");
                    else
                        MessageBox.Show(" Thêm thất bại !");
                }
                else
                    MessageBox.Show(" Tên đăng nhập  đã tồn tại !");

            }
        }
        public void update(NguoiDungDTO dto)
        {
            DialogResult dialogresult = MessageBox.Show("Bạn muốn cập nhật lại?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogresult == DialogResult.Yes)
            {
                if (dto == null)
                    MessageBox.Show("Cập nhật không thành công, xem lại thông tin cập nhật!", "Lỗi");
                else
                {
                    if (dto.TenDangNhap == "")
                    {
                        MessageBox.Show(" Tên đăng nhập không được trống !");
                    }
                    else
                    {
                        int result = dao.update(dto);
                        if (result > 0)
                            MessageBox.Show(" Cập nhật thông tin thành công !");
                        else
                            MessageBox.Show(" Cập nhật thông tin thất bại !");
                    }
                }
            }
        }

        public void updateMatKhau(NguoiDungDTO dto, string mkcu, string mkmoi1, string mkmoi2, ref bool bl)
        {
            DialogResult dialogresult = MessageBox.Show("Bạn muốn cập nhật mật khẩu lại?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogresult == DialogResult.Yes)
            {
                if (dto == null)
                    MessageBox.Show("Cập nhật không thành công, xem lại thông tin cập nhật!", "Lỗi");
                else
                {
                    if (dto.TenDangNhap == "")
                    {
                        MessageBox.Show(" Tên đăng nhập không được trống !");
                    }
                    else
                    {
                        if (!dto.MatKhau.Equals(mkcu))
                        {
                            MessageBox.Show("Nhập mật khẩu cũ không đúng!", "Lỗi");
                        }
                        else
                        {
                            if (!mkmoi1.Equals(mkmoi2))
                            {
                                MessageBox.Show("Nhập lại mật khẩu mới không khớp!", "Lỗi");
                            }
                            else
                            {
                                dto.MatKhau = mkmoi1;
                                int result = dao.update(dto);
                                if (result > 0)
                                {
                                    MessageBox.Show(" Cập nhật lại mật khẩu thành công !");
                                    bl = true;
                                }
                                else
                                    MessageBox.Show(" Cập nhật thất bại !");
                            }
                        }
                    }
                }
            }
        }

        public NguoiDungDTO getByPrimaryKey(int ma)
        {
            return dao.getByPrimaryKey(ma);
        }
        public void delete(int ma)
        {
            DialogResult result;
            if (ma == 1)
            {
                MessageBox.Show(" Đây là giá trị mặc định của admin, không thể xóa !");
            }
            else
            {
                result = MessageBox.Show("Bạn có thật sự muốn xóa người dùng này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
        public void delete(string tendangnhap)
        {
            if (tendangnhap == "")
                MessageBox.Show("Tên đăng nhập không được trống");
            else
            {
                DialogResult result;
                int ma = dao.getByTenDangNhap(tendangnhap).MaNguoiDung;
                if (ma == 1)
                {
                    MessageBox.Show(" Đây là giá trị mặc định của admin, không thể xóa !");
                }
                else
                {
                    result = MessageBox.Show("Bạn có thật sự muốn xóa người dùng này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
        }

        public NguoiDungDTO getFromTenDangNhap(string tenDN)
        {
            return dao.getByTenDangNhap(tenDN);
        }

        public bool checklogin(string tendn, string mk)
        {
            return dao.CheckLogin(tendn, mk);
        }

        public NguoiDungDTO[] getList()
        {
            return dao.getList();
        }
    }
}
