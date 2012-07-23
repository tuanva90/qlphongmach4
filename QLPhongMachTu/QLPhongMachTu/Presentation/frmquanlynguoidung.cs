using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLPhongMachTu.Presentation
{
    public partial class frmquanlynguoidung : Form
    {
        QuanLyNguoiDungBUS qlndbus = new QuanLyNguoiDungBUS();
        NguoiDungDTO nddto = new NguoiDungDTO();
        PhanQuyenDTO pqdto = new PhanQuyenDTO();
        public frmquanlynguoidung()
        {
            InitializeComponent();
        }

        private void frmquanlynguoidung_Load(object sender, EventArgs e)
        {
            btnxoa.Enabled = false;
            btnCapNhat.Enabled = false;
            btnreset.Enabled = false;
            qlndbus.showInListView(lvNguoiDung);
            qlndbus.showPhanQuyen(cbquyen);
            txttennguoidung.Text = "";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (btnthem.Text.Equals("Hủy"))
            {
                btnxoa.Enabled = false;
                btnCapNhat.Enabled = false;
                btnreset.Enabled = false;
                btnthem.Text = "Thêm";
                txttennguoidung.Text = "";
                txttennguoidung.Enabled = true;
            }
            else
            {
                nddto.TenDangNhap = txttennguoidung.Text;
                nddto.MatKhau = "123456";
                nddto.MaPhanQuyen = int.Parse(cbquyen.SelectedValue.ToString());
                qlndbus.insert(nddto);
                frmquanlynguoidung_Load(sender, e);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            qlndbus.delete(txttennguoidung.Text);
            frmquanlynguoidung_Load(sender, e);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (txttennguoidung.Text != "")
            {
                nddto = qlndbus.getFromTenDangNhap(txttennguoidung.Text);
                if(nddto != null)
                    nddto.MatKhau = "123456";
                qlndbus.update(nddto);
                frmquanlynguoidung_Load(sender, e);
            }
        }

        private void lvNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvNguoiDung.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvNguoiDung.SelectedItems[0];
                txttennguoidung.Text = lvi.SubItems[1].Text;
                cbquyen.Text = lvi.SubItems[2].Text;
            }
            btnthem.Text = "Hủy";
            btnxoa.Enabled = true;
            btnCapNhat.Enabled = true;
            btnreset.Enabled = true;
            txttennguoidung.Enabled = false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txttennguoidung.Text != "")
            {
                nddto = qlndbus.getFromTenDangNhap(txttennguoidung.Text);
                nddto.MaPhanQuyen = int.Parse(cbquyen.SelectedValue.ToString());
                qlndbus.update(nddto);
                frmquanlynguoidung_Load(sender, e);
            }
        }
    }
}
