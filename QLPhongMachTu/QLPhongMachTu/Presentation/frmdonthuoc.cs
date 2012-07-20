using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;

namespace QLPhongMachTu.Presentation
{
    public partial class frmdonthuoc : Form
    {
        BenhNhanBUS bnbus = new BenhNhanBUS();
        CT_KhamBUS ctkbus = new CT_KhamBUS();
        public frmdonthuoc()
        {
            InitializeComponent();
        }
        string mabenhnhan;
        string ngaykham;
        private void lvdsbenhnhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ngaykham = dtimengaykham.Text.ToString();
            if (this.lvdsbenhnhan.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvdsbenhnhan.SelectedItems[0];
                mabenhnhan = lvi.SubItems[1].Text;
                ctkbus.showInListView(lvdonthuoc, ctkbus.getListByMaPhieuKham(mabenhnhan + ngaykham));
            }
        }

        private void frmdonthuoc_Load(object sender, EventArgs e)
        {
            rdtheongay.Checked = true;
            dtimengaykham.Text = DateTime.Now.ToShortDateString();
            bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"));

        }

        private void dtimengaykham_Click(object sender, EventArgs e)
        {

        }

        private void dtimengaykham_TextChanged(object sender, EventArgs e)
        {
            if (rdtheongay.Checked == true)
            {
                bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"));              
            }
            else
            {
                bnbus.showInListView(lvdsbenhnhan, bnbus.getList());
            }
            lvdonthuoc.Items.Clear();
        }

        private void rdtheongay_CheckedChanged(object sender, EventArgs e)
        {
            bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"));
            lvdonthuoc.Items.Clear();
        }

        private void rdtatcabn_CheckedChanged(object sender, EventArgs e)
        {
            bnbus.showInListView(lvdsbenhnhan, bnbus.getList());
            lvdonthuoc.Items.Clear();

        }
    }
}
