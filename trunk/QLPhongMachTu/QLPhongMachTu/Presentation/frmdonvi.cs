using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QLPhongMachTu.Presentation
{
    public partial class frmdonvi : Form
    {
        DonViBUS dvbus = new DonViBUS();
        DonViDTO dvdto = new DonViDTO();
        public frmdonvi()
        {
            InitializeComponent();
        }

        private void txtmadonvi_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvDonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvDonViTinh.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvDonViTinh.SelectedItems[0];
                txttendonvi.Text = lvi.SubItems[1].Text;
               txtma.Text = lvi.SubItems[2].Text;
                
            }
            btnthem.Text = "Hủy";
            btnxoa.Enabled = true;
            btnsua.Enabled = true;

        }

        private void frmdonvi_Load(object sender, EventArgs e)
        {
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            dvbus.showInListView(lvDonViTinh);
            txttendonvi.Text = "";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (btnthem.Text == "Hủy")
            {
                btnxoa.Enabled = false;
                btnsua.Enabled = false;
                btnthem.Text = "Thêm";
                txttendonvi.Text = "";
            }
            else
            {
                dvdto.DonViTinh = txttendonvi.Text.ToString();
                dvbus.insert(dvdto);
                dvbus.showInListView(lvDonViTinh);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            dvbus.delete(int.Parse(txtma.Text.ToString()));
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            btnthem.Text = "Thêm";
            txttendonvi.Text = "";
            dvbus.showInListView(lvDonViTinh);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            dvdto.MaDonViTinh = int.Parse(txtma.Text.ToString());
            dvdto.DonViTinh = txttendonvi.Text.ToString();
            dvbus.update(dvdto);
            dvbus.showInListView(lvDonViTinh);
        }
    }
}
