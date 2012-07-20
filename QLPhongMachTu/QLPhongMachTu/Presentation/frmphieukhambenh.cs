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
    public partial class frmphieukhambenh : Form
    {
        BenhNhanBUS bnbus = new BenhNhanBUS();
        LoaiBenhBUS lbbus = new LoaiBenhBUS();
        LoaiThuocBUS ltbus = new LoaiThuocBUS();
        CachDungBUS cdbus = new CachDungBUS();
        DonViBUS dvbus = new DonViBUS();
        CachDungDTO cddto;
        CT_KhamBUS ctkbus = new CT_KhamBUS();
        CT_KhamDTO ctkdto;
        PhieuKhamBenhDTO pkbdto;
        PhieuKhamBenhBUS pkbbus = new PhieuKhamBenhBUS();      
       
        public frmphieukhambenh()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void navigationPanePanel1_Click(object sender, EventArgs e)
        {

        }

        private void frmphieukhambenh_Load(object sender, EventArgs e)
        {           
            dtimengaykham.Text = DateTime.Now.ToShortDateString();
           // bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(),"in"));
            bnbus.showBNChuaLapPhieuKham(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"),dtimengaykham.Text.ToString());
            // do du lieu len commbobox
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = lbbus.getList();
            cbloaibenhchinh.DataSource = bindingSource1.DataSource;
            cbloaibenhchinh.DisplayMember = "TenLoaiBenh";
            cbloaibenhchinh.ValueMember = "MaLoaiBenh";
            //
            BindingSource bindingSource2 = new BindingSource();
            bindingSource2.DataSource = lbbus.getList();
            cbloaibenhphu.DataSource = bindingSource2.DataSource;
            cbloaibenhphu.DisplayMember = "TenLoaiBenh";
            cbloaibenhphu.ValueMember = "MaLoaiBenh";
            //
            BindingSource bindingSource3 = new BindingSource();
            bindingSource3.DataSource = ltbus.getList();
          
            cmbloaithuoc.DataSource = bindingSource3.DataSource;
            cmbloaithuoc.DisplayMember = "TenLoaiThuoc";
            cmbloaithuoc.ValueMember = "MaLoaiThuoc";  
            grketquakham.Enabled = false;
            grlaythuoc.Enabled = false;
            

        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void expandablePanel3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void navigationPane1_Load(object sender, EventArgs e)
        {

        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel4_Click(object sender, EventArgs e)
        {

        }

        private void dtimengaykham_Click(object sender, EventArgs e)
        {
           
        }

        private void dtimengaykham_TextChanged(object sender, EventArgs e)
        {
            if (dtimengaykham.Text.Equals(DateTime.Now.ToShortDateString().ToString()) == false)
            {
                grketquakham.Enabled = false;
                grlaythuoc.Enabled = false;
            }
            else
            {
                 
            }
            lblmabenhnhan.Text = "";
            lbltenbenhnhan.Text = "";
            lblgioitinh.Text = "";
            lblngaysinh.Text = "";
            lbldiachi.Text = "";
            exp1.TitleText = "Danh sách BN khám trong ngày";
            bnbus.showBNChuaLapPhieuKham(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"), dtimengaykham.Text.ToString());
            lvdonthuocganday.Items.Clear();
        }

        private void btnlapphieukham_Click(object sender, EventArgs e)
        {
                 pkbdto = new PhieuKhamBenhDTO();
                pkbdto.MaBenhNhan = lblmabenhnhan.Text.ToString();
                pkbdto.NgayKham = dtimengaykham.Text.ToString();
                pkbdto.TrieuChung = txttrieuchung.Text.ToString();
                pkbdto.MaLoaiBenh = int.Parse(cbloaibenhchinh.SelectedValue.ToString());
                pkbdto.MaLoaiBenhPhu = int.Parse(cbloaibenhphu.SelectedValue.ToString());
                if (pkbbus.insert(pkbdto) > 0)
                {
                    btnlapphieukham.Enabled = false;
                    btnsuaphieukham.Enabled = true;
                    grlaythuoc.Enabled = true;
                    bnbus.showBNChuaLapPhieuKham(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"), dtimengaykham.Text.ToString());                }
        }

        private void cbloaibenhchinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvdsbenhnhan_SelectedIndexChanged(object sender, EventArgs e)
        {
                lvdonthuocganday.Items.Clear();
                expandablePanel1.Expanded = false;
                cmbloaithuoc_SelectedIndexChanged(sender, e);
                if (this.lvdsbenhnhan.SelectedItems.Count > 0)
                {
                    pkbdto = new PhieuKhamBenhDTO();
                    ListViewItem lvi = this.lvdsbenhnhan.SelectedItems[0];
                    lblmabenhnhan.Text = lvi.SubItems[1].Text;
                    lbltenbenhnhan.Text = lvi.SubItems[2].Text;
                    lblgioitinh.Text = lvi.SubItems[3].Text;
                    lblngaysinh.Text = lvi.SubItems[4].Text;
                    lbldiachi.Text = lvi.SubItems[6].Text;
                    grketquakham.Enabled = true;
                    exp1.Expanded = false;
                       if (dtimengaykham.Text.Equals(DateTime.Now.ToShortDateString().ToString()) == false)
                            {
                                grketquakham.Enabled = false;
                                grlaythuoc.Enabled = false;
                            }
                            else
                            {
                            pkbdto = pkbbus.getByPrimaryKey(lblmabenhnhan.Text.ToString(), dtimengaykham.Text.ToString());
                            if (pkbdto == null)
                            {
                                btnlapphieukham.Enabled = true;
                                btnsuaphieukham.Enabled = false;
                                grlaythuoc.Enabled = false;
                                lvDonThuoc.Items.Clear();
                            }
                            else
                            {
                                btnlapphieukham.Enabled = false;
                                btnsuaphieukham.Enabled = true;
                                grlaythuoc.Enabled = true;
                                txttrieuchung.Text = pkbdto.TrieuChung;
                                cbloaibenhchinh.Text = lbbus.getByPrimaryKey(pkbdto.MaLoaiBenh).TenLoaiBenh.ToString();
                                cbloaibenhphu.Text = lbbus.getByPrimaryKey(pkbdto.MaLoaiBenhPhu).TenLoaiBenh.ToString();
                                ctkbus.showInListView(lvDonThuoc, ctkbus.getListByMaPhieuKham(lblmabenhnhan.Text + dtimengaykham.Text));
                                txttrieuchung.Text = "";
                               // ctkbus.showInListView1(lvdonthuocganday, ctkbus.getListByBenhNhan(lblmabenhnhan.Text.ToString()));
                            }
                            exp1.TitleText = " Bệnh nhân : " + lblmabenhnhan.Text;
                            // tuy chinh menu them, xoa , sua don thuoc
                            cmbloaithuoc.Enabled = true;
                            btSua.Enabled = false;
                            btXoa.Enabled = false;
                            btThem.Enabled = true;
                            btnhuy.Enabled = false;
                        }
            }
        }

        private void btnsuaphieukham_Click(object sender, EventArgs e)
        {
             pkbdto = new PhieuKhamBenhDTO();
                pkbdto.MaBenhNhan = lblmabenhnhan.Text.ToString();
                pkbdto.NgayKham = dtimengaykham.Text.ToString();
                pkbdto.TrieuChung = txttrieuchung.Text.ToString();
                pkbdto.MaLoaiBenh = int.Parse(cbloaibenhchinh.SelectedValue.ToString());
                pkbdto.MaLoaiBenhPhu = int.Parse(cbloaibenhphu.SelectedValue.ToString());
                pkbbus.update(pkbdto);
          }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
       
        int macachdung;    
        private void lvDonThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvDonThuoc.SelectedItems.Count > 0)
            {
                pkbdto = new PhieuKhamBenhDTO();
                ListViewItem lvi = this.lvDonThuoc.SelectedItems[0];
                cmbloaithuoc.Text = lvi.SubItems[1].Text.ToString();
               lbldonvi.Text = lvi.SubItems[2].Text;
               cmbsoluong.Text = lvi.SubItems[3].Text;
               macachdung = int.Parse(lvi.SubItems[4].Text);
               cddto = cdbus.getByPrimaryKey(int.Parse(lvi.SubItems[4].Text));
               txtcachdung.Text = cddto.CachDung;
               txtghichu.Text = cddto.GhiChu;
               txtsang.Text = cddto.Sang.ToString();
               txttrua.Text = cddto.Trua.ToString();
               txtchieu.Text = cddto.Chieu.ToString();
               txttoi.Text = cddto.Toi.ToString();
               cmbloaithuoc.Enabled = false;
               btSua.Enabled = true;
               btXoa.Enabled = true;
               btThem.Enabled = false;
               btnhuy.Enabled = true;
               lbldongia.Text = ltbus.getByPrimaryKey(int.Parse(cmbloaithuoc.SelectedValue.ToString())).DonGia.ToString();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (pkbbus.getByPrimaryKey(lblmabenhnhan.Text.ToString(), dtimengaykham.Text.ToString()) != null)
            {
                MessageBox.Show(" Hóa đơn trong ngày của bệnh nhân này đã được lập, không thể kê thêm thuốc !");
            }
            else
            {
                if (float.Parse(cmbsoluong.Text.ToString()) > ltbus.getByPrimaryKey(int.Parse(cmbloaithuoc.SelectedValue.ToString())).SoLuong)
                {
                    MessageBox.Show(" Số lượng loại thuốc này trong kho không đủ !");
                }
                else
                {
                    ctkdto = new CT_KhamDTO();
                    cddto = new CachDungDTO();
                    ctkdto.MaPhieuKhamBenh = lblmabenhnhan.Text.ToString() + dtimengaykham.Text;
                    ctkdto.DonGia = float.Parse(lbldongia.Text.ToString());
                    ctkdto.MaLoaiThuoc = int.Parse(cmbloaithuoc.SelectedValue.ToString());
                    ctkdto.SoLuong = float.Parse(cmbsoluong.Text.ToString());

                    cddto.CachDung = txtcachdung.Text.ToString();
                    cddto.GhiChu = txtghichu.Text.ToString();
                    cddto.Sang = float.Parse(txtsang.Text.ToString());
                    cddto.Trua = float.Parse(txttrua.Text.ToString());
                    cddto.Chieu = float.Parse(txtchieu.Text.ToString());
                    cddto.Toi = float.Parse(txttoi.Text.ToString());

                    ctkbus.insert(ctkdto, cddto);
                    if (float.Parse(cmbsoluong.Text.ToString()) == 0)
                    {
                        MessageBox.Show(" Số lượng thuốc kê đơn phải >0 !");
                    }
                    else
                    {
                        ctkbus.showInListView(lvDonThuoc, ctkbus.getListByMaPhieuKham(lblmabenhnhan.Text + dtimengaykham.Text));
                    }
                }
            }
        }

        private void txtsang_TextChanged(object sender, EventArgs e)
        {
            if (txtsang.Text != "")
            {
                try
                {
                    float check = float.Parse(txtsang.Text.ToString());
                }
                catch
                {
                    MessageBox.Show(" Số lượng thuốc uống buổi sáng chưa đúng định dạng, vui lòng nhập lại !");
                    txtsang.Focus();
                }
            }
        }

        private void txttrua_TextChanged(object sender, EventArgs e)
        {
            if (txttrua.Text != "")
            {
                try
                {
                    float check = float.Parse(txttrua.Text.ToString());
                }
                catch
                {
                    MessageBox.Show(" Số lượng thuốc uống buổi trua chưa đúng định dạng, vui lòng nhập lại !");
                    txttrua.Focus();
                }
            }
        }

        private void txtchieu_TextChanged(object sender, EventArgs e)
        {
            if (txtchieu.Text != "")
            {
                try
                {
                    float check = float.Parse(txtchieu.Text.ToString());
                }
                catch
                {
                    MessageBox.Show(" Số lượng thuốc uống buổi chieu chưa đúng định dạng, vui lòng nhập lại !");
                    txtchieu.Focus();
                }
            }
        }

        private void txttoi_TextChanged(object sender, EventArgs e)
        {
            if (txttoi.Text != "")
            {
                try
                {
                    float check = float.Parse(txttoi.Text.ToString());
                }
                catch
                {
                    MessageBox.Show(" Số lượng thuốc uống buổi toi chưa đúng định dạng, vui lòng nhập lại !");
                    txttoi.Focus();
                }
            }
        }

        private void cmbsoluong_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbloaithuoc_SelectedIndexChanged(sender, e);
        }

        private void cmbsoluong_TextChanged(object sender, EventArgs e)
        {
            if (cmbsoluong.Text != "")
            {
                try
                {
                    float check = float.Parse(cmbsoluong.Text.ToString());
                    cmbloaithuoc_SelectedIndexChanged(sender, e);
                }
                catch
                {
                    MessageBox.Show(" Số lượng thuốc chưa đúng định dạng, vui lòng nhập lại!");
                    cmbsoluong.Focus();
                }
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ma cach dung : " + macachdung + " ma loai thuoc " + cmbloaithuoc.SelectedValue + lblmabenhnhan.Text + dtimengaykham.Text);
            ctkbus.delete(lblmabenhnhan.Text + dtimengaykham.Text, int.Parse(cmbloaithuoc.SelectedValue.ToString()), macachdung);
           ctkbus.showInListView(lvDonThuoc, ctkbus.getListByMaPhieuKham(lblmabenhnhan.Text + dtimengaykham.Text));
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            cddto = new CachDungDTO();
            cddto.CachDung = txtcachdung.Text.ToString();
            cddto.MaCachDung = macachdung;
            cddto.Sang = float.Parse(txtsang.Text.ToString());
            cddto.Trua = float.Parse(txttrua.Text.ToString());
            cddto.Chieu = float.Parse(txtchieu.Text.ToString());
            cddto.Toi = float.Parse(txttoi.Text.ToString());
            cddto.GhiChu = txtghichu.Text.ToString();
            cdbus.update(cddto);
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            cmbloaithuoc.Enabled = true;
            btSua.Enabled = false;
            btXoa.Enabled = false;
            btThem.Enabled = true;
            btnhuy.Enabled = false;
        }

        private void cmbloaithuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {            
                int madonvitinh = ltbus.getByPrimaryKey(int.Parse(cmbloaithuoc.SelectedValue.ToString())).MaDonViTinh;
                lbldonvi.Text = dvbus.getByPrimaryKey(madonvitinh).DonViTinh.ToString();
                lbldongia.Text = ltbus.getByPrimaryKey(int.Parse(cmbloaithuoc.SelectedValue.ToString())).DonGia.ToString();
            }
            catch
            {
            }
        }

        private void txtsang_Leave(object sender, EventArgs e)
        {
            if(txtsang.Text=="")
                txtsang.Text = "0";
            try
            {
                float check = float.Parse(txtsang.Text.ToString());
            }
            catch
            {
                txtsang.Text = "0";
            }
        }

        private void txttrua_Leave(object sender, EventArgs e)
        {
            if (txttrua.Text == "")
                txttrua.Text = "0";
            try
            {
                float check = float.Parse(txttrua.Text.ToString());
            }
            catch
            {
                txttrua.Text = "0";
            }
        }

        private void txtchieu_Leave(object sender, EventArgs e)
        {
            if (txtchieu.Text == "")
                txtchieu.Text = "0";
            try
            {
                float check = float.Parse(txtchieu.Text.ToString());
            }
            catch
            {
                txtchieu.Text = "0";
            }
        }

        private void txttoi_Leave(object sender, EventArgs e)
        {
            if (txttoi.Text == "")
                txttoi.Text = "0";
            try
            {
                float check = float.Parse(txttoi.Text.ToString());
            }
            catch
            {
                txttoi.Text = "0";
            }
        }

        private void cmbsoluong_Leave(object sender, EventArgs e)
        {
            if (cmbsoluong.Text == "")
                cmbsoluong.Text = "1";
            try
            {
                float check = float.Parse(cmbsoluong.Text.ToString());
                }
            catch
            {
                cmbsoluong.Text = "1";
            }
        }

        private void expandablePanel1_ExpandedChanging(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
        }

        private void expandablePanel1_Click(object sender, EventArgs e)
        {

        }

        private void btndonthuocganday_Click(object sender, EventArgs e)
        {
            ctkbus.showInListView1(lvdonthuocganday, ctkbus.getListByBenhNhan(lblmabenhnhan.Text.ToString()));
        }

        private void expandablePanel1_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {   }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            bnbus.showBNChuaLapPhieuKham(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"), dtimengaykham.Text.ToString());
        }

    }
}
