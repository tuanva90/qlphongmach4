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
    public partial class frmLoaiThuoc : Form
    {
        DonViBUS dvbus = new DonViBUS();
        LoaiThuocBUS ltbus = new LoaiThuocBUS();
        LoaiThuocDTO ltdto;
        NhapKhoDTO nkdto;
        
        public frmLoaiThuoc()
        {
            InitializeComponent();
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            nkdto = new NhapKhoDTO();
            nkdto.MaLoaiThuoc = int.Parse(txtmaloaithuoc.Text.ToString());
            nkdto.NgayNhap = lblngaynhap.Text.ToString();
            nkdto.SoLuong = float.Parse(txtsoluong.Text.ToString());
            nkdto.DonGiaNhap = float.Parse(txtdongia.Text.ToString());
            nkdto.LanNhap = int.Parse(lbllannhap.Text.ToString());
            ltbus.nhapkho(nkdto);
            ltbus.showInListView(lvLoaiThuoc);
            lbllannhap.Text = (ltbus.getMaxLanNhap(int.Parse(txtmaloaithuoc.Text.ToString()))).ToString();  
        }

        private void frmLoaiThuoc_Load(object sender, EventArgs e)
        {
            //
            BindingSource bindingSource2 = new BindingSource();
            bindingSource2.DataSource = dvbus.getList();
            cmbdonvitinh.DataSource = bindingSource2.DataSource;
            cmbdonvitinh.DisplayMember = "DonViTinh";
            cmbdonvitinh.ValueMember = "MaDonViTinh";

            lblngaynhap.Text = DateTime.Now.ToShortDateString();
            ltbus.showInListView(lvLoaiThuoc);
            btnthemthuoc.Text = "Thêm";
        }

        private void btnthemthuoc_Click(object sender, EventArgs e)
        {
            if (btnthemthuoc.Text == "Thêm")
            {
                ltdto = new LoaiThuocDTO();
                ltdto.TenLoaiThuoc = txttenloaithuoc.Text.ToString();
                ltdto.SoLuong = 0;
                ltdto.MaDonViTinh = int.Parse(cmbdonvitinh.SelectedValue.ToString());
                if(ltbus.insert(ltdto)>0)
                    ltbus.showInListView(lvLoaiThuoc);
            }
            else
            {
                txtmaloaithuoc.Text = "";
                txttenloaithuoc.Text = "";
                btnthemthuoc.Text = "Thêm";              
                btnxoathuoc.Enabled = false;
                btnsuathuoc.Enabled = false;
            }
        }

        private void lvLoaiThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvLoaiThuoc.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvLoaiThuoc.SelectedItems[0];
                txtmaloaithuoc.Text = lvi.SubItems[1].Text;
                txttenloaithuoc.Text = lvi.SubItems[2].Text;
                cmbdonvitinh.Text = lvi.SubItems[2].Text.ToString();
                lblloaithuoc.Text = txttenloaithuoc.Text;
                lbllannhap.Text = (ltbus.getMaxLanNhap(int.Parse(txtmaloaithuoc.Text.ToString()))).ToString();             
                btnthemthuoc.Text = "Hủy";
                btnsuathuoc.Enabled = true;
                btnxoathuoc.Enabled = true;
                lbldonvi.Text = lvi.SubItems[2].ToString();
            }
        }

        private void btnxoathuoc_Click(object sender, EventArgs e)
        {            
            btnthemthuoc.Text = "Thêm";
            btnxoathuoc.Enabled = false;
            btnsuathuoc.Enabled = false;
            MessageBox.Show(txtmaloaithuoc.Text);
            if(ltbus.delete(int.Parse(txtmaloaithuoc.Text.ToString()))>0)
                ltbus.showInListView(lvLoaiThuoc);
            txtmaloaithuoc.Text = "";
            txttenloaithuoc.Text = "";
            lblloaithuoc.Text = "";
        }

        private void btnsuathuoc_Click(object sender, EventArgs e)
        {
             ltdto = new LoaiThuocDTO();
             ltdto.MaLoaiThuoc = int.Parse(txtmaloaithuoc.Text.ToString());
             ltdto.TenLoaiThuoc = txttenloaithuoc.Text.ToString();
             ltdto.MaDonViTinh=int.Parse(cmbdonvitinh.SelectedValue.ToString());
             if (ltbus.update(ltdto) > 0)
                {
                ltbus.showInListView(lvLoaiThuoc);
                lbldonvi.Text = cmbdonvitinh.Text.ToString();
             }
            btnthemthuoc.Text = "Hủy";            
        }

        private void txttenloaithuoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupPanel4_Click(object sender, EventArgs e)
        {

        }

        private void panelEx3_Click(object sender, EventArgs e)
        {

        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            if (txtsoluong.Text != "")
            {
                try
                {
                    float check = float.Parse(txtsoluong.Text.ToString());
                }
                catch
                {
                    MessageBox.Show(" Số lượng thuốc chưa đúng định dạng, vui lòng nhập lại !");
                    txtsoluong.Focus();
                }
            }
        }

        private void txtsoluong_Leave(object sender, EventArgs e)
        {

            if (txtsoluong.Text == "")
                txtsoluong.Text = "1";
            try
            {
                float check = float.Parse(txtsoluong.Text.ToString());
            }
            catch
            {
                txtsoluong.Text = "1";
            }
        }

        private void txtdongia_TextChanged(object sender, EventArgs e)
        {
            if (txtdongia.Text != "")
            {
                try
                {
                    float check = float.Parse(txtdongia.Text.ToString());
                }
                catch
                {
                    MessageBox.Show(" Đơn giá chưa đúng định dạng, vui lòng nhập lại !");
                    txtdongia.Focus();
                }
            }
        }

        private void txtdongia_Leave(object sender, EventArgs e)
        {
            if (txtdongia.Text == "")
                txtdongia.Text = "1000";
            try
            {
                float check = float.Parse(txtdongia.Text.ToString());
            }
            catch
            {
                txtdongia.Text = "1000";
            }
        }
    }
}
