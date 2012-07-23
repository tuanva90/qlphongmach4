using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BUS;

namespace QLPhongMachTu.Presentation
{
    public partial class frmdangnhap : Form
    {
        QuanLyNguoiDungBUS qlndbus = new QuanLyNguoiDungBUS();
        public frmdangnhap()
        {
            InitializeComponent();
        }

        private void txttendangnhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex re = new Regex(@"^\w+$");
            if (!re.IsMatch(e.KeyChar.ToString()) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txttendangnhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btndangnhap_Click(sender, e);
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            if (qlndbus.checklogin(txttendangnhap.Text, txtmatkhau.Text))
            {
                Form1.user = qlndbus.getFromTenDangNhap(txttendangnhap.Text);
                this.Close();
            }
        }

        private void txtmatkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btndangnhap_Click(sender, e);
        }

        private void txtmatkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex re = new Regex(@"^\w+$");
            if (!re.IsMatch(e.KeyChar.ToString()) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnhuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
