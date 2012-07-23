using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLPhongMachTu.Presentation
{
    public partial class frmdoimatkhau : Form
    {
        public frmdoimatkhau()
        {
            InitializeComponent();
        }

        private void frmdoimatkhau_Load(object sender, EventArgs e)
        {
            if (Form1.user != null)
            {
                lbTenDangNhap.Text = Form1.user.TenDangNhap;
                txtmatkhaucu.Text = "";
                txtmatkhaumoi.Text = "";
                txtmatkhaumoi2.Text = "";
            }
        }

        private void btndongy_Click(object sender, EventArgs e)
        {
            bool bl = false;
            if (txtmatkhaucu.Text == "" || txtmatkhaumoi.Text == "" || txtmatkhaumoi2.Text == "")
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo");
            else
                new BUS.QuanLyNguoiDungBUS().updateMatKhau(Form1.user, txtmatkhaucu.Text, txtmatkhaumoi.Text, txtmatkhaumoi2.Text, ref bl);
            if (bl)
                this.Close();
        }

        private void txtmatkhaumoi2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btndongy_Click(sender, e);
        }
    }
}
