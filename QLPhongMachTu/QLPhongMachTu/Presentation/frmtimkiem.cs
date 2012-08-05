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
    public partial class frmtimkiem : Form
    {
        HoaDonBUS hdbus = new HoaDonBUS();
        PhieuKhamBenhBUS pkbus = new PhieuKhamBenhBUS();
        BenhNhanBUS bnbus = new BenhNhanBUS();
        BenhNhanDTO bndto;
        public frmtimkiem()
        {
            InitializeComponent();
        }

        private void frmtimkiem_Load(object sender, EventArgs e)
        {

        }

        private void txtmabn_hd_TextChanged(object sender, EventArgs e)
        {
            btninhoadon.Enabled = false;
            if (txtmabn_hd.TextLength == 5)
            {
                bndto = bnbus.getByPrimaryKey(txtmabn_hd.Text.ToString());
                if (bndto != null)
                {
                    hdbus.showByBenhNhan(lvhoadon, txtmabn_hd.Text.ToString());
                    lbltenbenhnhan.Text = bndto.HoTen;
                    lblgioitinh.Text = bndto.GioiTinh;
                    lblnamsinh.Text = bndto.NamSinh;
                }
            }
            else
            {
                lblnamsinh.Text = "";
                lblgioitinh.Text = "";
                lblngaylap.Text = "";
                lbltenbenhnhan.Text = "";
                lvhoadon.Items.Clear();
            }
        }

        private void lvhoadon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvhoadon.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvhoadon.SelectedItems[0];
                lblngaylap.Text = lvi.SubItems[1].Text;
                btninhoadon.Enabled = true;
            }
        }

        private void txtmabn_pk_TextChanged(object sender, EventArgs e)
        {
           btninpk.Enabled = false;
            if (txtmabn_pk.TextLength == 5)
            {
                bndto = bnbus.getByPrimaryKey(txtmabn_pk.Text.ToString());
                if (bndto != null)
                {
                    pkbus.showPKByBenhNhan(lvphieukham, txtmabn_pk.Text.ToString());
                    lbltenbn_pk.Text = bndto.HoTen;
                    lblgioitinh_pk.Text = bndto.GioiTinh;
                    lblnamsinh_pk.Text = bndto.NamSinh;
                }
            }
            else
            {
                lblnamsinh_pk.Text = "";
                lblgioitinh_pk.Text = "";
                lblngaykham_pk.Text = "";
                lbltenbn_pk.Text = "";
                lvphieukham.Items.Clear();
            }
        }

        private void lvphieukham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvphieukham.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvphieukham.SelectedItems[0];
                lblngaykham_pk.Text = lvi.SubItems[1].Text;
                btninpk.Enabled = true;
            }
        }

        private void btninhoadon_Click(object sender, EventArgs e)
        {
            KHAIBAO.mabenhnhan = txtmabn_hd.Text.ToString();
            KHAIBAO.ngaykham = lblngaylap.Text.ToString();
            Presentation.frminhoadon frm = new frminhoadon();
            frm.ShowDialog();
        }
    }
}
