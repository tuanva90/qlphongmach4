using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DTO;
using BUS;
using System.Windows.Forms;

namespace QLPhongMachTu.Presentation
{
    public partial class frmloaibenh : Form
    {
        LoaiBenhBUS lbbus = new LoaiBenhBUS();
        LoaiBenhDTO lbdto = new LoaiBenhDTO();
        public frmloaibenh()
        {
            InitializeComponent();
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void frmloaibenh_Load(object sender, EventArgs e)
        {
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            lbbus.showInListView(lvloaibenh);
            txtloaibenh.Text = "";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (btnthem.Text == "Hủy")
            {
                btnxoa.Enabled = false;
                btnsua.Enabled = false;
                btnthem.Text = "Thêm";
                txtloaibenh.Text = "";             }
            else
            {
                lbdto.TenLoaiBenh =  txtloaibenh.Text.ToString();
                lbbus.insert(lbdto);
                lbbus.showInListView(lvloaibenh);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            lbbus.delete(int.Parse(txtma.Text.ToString()));
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            btnthem.Text = "Thêm";
            txtloaibenh.Text = "";
            lbbus.showInListView(lvloaibenh);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            lbdto.MaLoaiBenh = int.Parse(txtma.Text.ToString());
            lbdto.TenLoaiBenh = txtloaibenh.Text.ToString();
            lbbus.update(lbdto);
            lbbus.showInListView(lvloaibenh);
        }

        private void lvloaibenh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvloaibenh.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvloaibenh.SelectedItems[0];
                txtloaibenh.Text = lvi.SubItems[1].Text;
                txtma.Text = lvi.SubItems[2].Text;

            }
            btnthem.Text = "Hủy";
            btnxoa.Enabled = true;
            btnsua.Enabled = true;

        }
    }
}
