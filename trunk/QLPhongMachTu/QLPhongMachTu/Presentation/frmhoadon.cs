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
using CrystalDecisions.CrystalReports.Engine;

namespace QLPhongMachTu.Presentation
{
    public partial class frmhoadon : Form
    {
        BenhNhanBUS bnbus = new BenhNhanBUS();
        CT_KhamBUS ctkbus = new CT_KhamBUS();
        LoaiThuocBUS lbbus = new LoaiThuocBUS();
        CT_KhamDTO[] listctk;
        ThamSoBUS tsbus = new ThamSoBUS();
        HoaDonBUS hdbus = new HoaDonBUS();
        HoaDonDTO hddto;
        public frmhoadon()
        {
            InitializeComponent();
        }
       //string mabenhnhan;
        string ngaykham;
        float tongtien;
        private void lvdsbenhnhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ngaykham = dtimengaykham.Text.ToString();
            if (this.lvdsbenhnhan.SelectedItems.Count > 0)
            {
                tongtien = 0;              
                ListViewItem lvi = this.lvdsbenhnhan.SelectedItems[0];
                lblmabenhnhan.Text = lvi.SubItems[1].Text;
                lbltenbenhnhan.Text = lvi.SubItems[2].Text.ToString();
                lblgioitinh.Text = lvi.SubItems[3].Text.ToString();
                lblnamsinh.Text = lvi.SubItems[4].Text.ToString();
                lblngaykham.Text = dtimengaykham.Text.ToString();                 
                if (dtimengaykham.Text.Equals(DateTime.Now.ToShortDateString().ToString()) == false)
                {
                    btnindonthuoc.Enabled = false;
                    checkBoxMuathuoc.Enabled = false;
                    btninhoadon.Enabled = true;
                    if (hdbus.getByPrimaryKey(lblmabenhnhan.Text.ToString() + dtimengaykham.Text.ToString()) != null)
                    {
                        btninhoadon.Enabled = true;
                    }
                    else
                    {
                        btninhoadon.Enabled = false;
                        lbltienthuoc.Text = "0";
                        lbltongcong.Text = "0";
                    }
                }
                else
                {
                    if (hdbus.getByPrimaryKey(lblmabenhnhan.Text.ToString() + dtimengaykham.Text.ToString()) != null)
                    {  
                             hddto= new HoaDonDTO();
                             hddto = hdbus.getByPrimaryKey(lblmabenhnhan.Text.ToString() + dtimengaykham.Text.ToString());
                             lbltienkham.Text=hddto.TienKham.ToString();
                             lbltienthuoc.Text=hddto.TienThuoc.ToString();
                            //lbltongcong.Text = (hddto.TienThuoc+hddto.TienKham).ToString();
                            tongtien += hddto.TienThuoc;
                            tongtien += float.Parse(lbltienkham.Text.ToString());
                            btnindonthuoc.Enabled = false;
                            checkBoxMuathuoc.Enabled = false;
                             btninhoadon.Enabled = true;                         
                            if (lbltienthuoc.Text == "0")
                                checkBoxMuathuoc.Checked = false;
                            else
                                checkBoxMuathuoc.Checked = true;
                    }
                    else
                    {
                        listctk = ctkbus.getListByMaPhieuKham(lblmabenhnhan.Text.ToString() + dtimengaykham.Text.ToString());
                        if (listctk != null)
                        {
                            for (int i = 0; i < listctk.Length; i++)
                            {
                                tongtien += float.Parse(listctk[i].SoLuong.ToString()) * float.Parse(listctk[i].DonGia.ToString());
                            }
                            lbltienthuoc.Text = tongtien.ToString();
                            tongtien += float.Parse(lbltienkham.Text.ToString());
                            checkBoxMuathuoc.Enabled = true;
                            checkBoxMuathuoc.Checked = true;                           
                        }
                        else
                        {
                            lbltienthuoc.Text = "0";
                          //  lbltongcong.Text = lbltienkham.Text;
                            tongtien += float.Parse(lbltienkham.Text.ToString());
                            checkBoxMuathuoc.Checked = false;
                            checkBoxMuathuoc.Enabled = false;                          
                        }
                        btnindonthuoc.Enabled = true;
                        btninhoadon.Enabled = false;                      
                    }
                }               
                lbltongcong.Text = tongtien.ToString();
            }
        }

        private void frmdonthuoc_Load(object sender, EventArgs e)
        {
           
            dtimengaykham.Text = DateTime.Now.ToShortDateString();
            bnbus.showBNChuaLapHD(lvdsbenhnhan, bnbus.getListByPhieuKham(dtimengaykham.Text.ToString(), "in"),dtimengaykham.Text.ToString());
            lbltienkham.Text = tsbus.getThamSo().TienKham.ToString();

        }

        private void dtimengaykham_Click(object sender, EventArgs e)
        {

        }

        private void dtimengaykham_TextChanged(object sender, EventArgs e)
        {           
            lblmabenhnhan.Text = "";
            lbltenbenhnhan.Text = "";
            lblgioitinh.Text = "";
            lblnamsinh.Text = "";
            lblngaykham.Text = "";
            lbltongcong.Text = "";
            btnindonthuoc.Enabled = false;
            checkBoxMuathuoc.Enabled = false;
            btninhoadon.Enabled = false;
            bnbus.showBNChuaLapHD(lvdsbenhnhan, bnbus.getListByPhieuKham(dtimengaykham.Text.ToString(), "in"), dtimengaykham.Text.ToString());
        }

        private void rdtheongay_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdtatcabn_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void labelX6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void labelX5_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxMuathuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMuathuoc.Checked == false)
            {
                lbltienthuoc.Text = "0";
                lbltongcong.Text = lbltienkham.Text;
            }
            else
            {
               lbltongcong.Text = tongtien.ToString();
               lbltienthuoc.Text = (tongtien - float.Parse(lbltienkham.Text.ToString())).ToString();
            }
        }

        private void btnindonthuoc_Click(object sender, EventArgs e)
        {
            DialogResult result;
             result = MessageBox.Show("Bạn có thật sự muốn lập hóa đơn cho bệnh nhân : " + lbltenbenhnhan.Text + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (result == DialogResult.Yes)
             {
                 hddto = new HoaDonDTO();
                 hddto.MaPhieuKhamBenh = lblmabenhnhan.Text.ToString() + lblngaykham.Text.ToString();
                 hddto.TienKham = float.Parse(lbltienkham.Text.ToString());
                 if (checkBoxMuathuoc.Checked == true)
                 {
                     LoaiThuocDTO ltdto;
                     bool check = false;
                     listctk = ctkbus.getListByMaPhieuKham(lblmabenhnhan.Text.ToString() + dtimengaykham.Text.ToString());
                     for (int i = 0; i < listctk.Length; i++)
                     {
                         ltdto = new LoaiThuocDTO();
                         ltdto.MaLoaiThuoc = listctk[i].MaLoaiThuoc;
                         ltdto.SoLuong = lbbus.getByPrimaryKey(ltdto.MaLoaiThuoc).SoLuong - listctk[i].SoLuong;
                         if (ltdto.SoLuong < 0)
                         {
                             //MessageBox.Show(" Số lượng thuốc trong kho không đủ cho hóa đơn này, vui lòng nhập thuốc hoặc để bệnh nhân lấy thuốc ở ngoài !");
                             check = true;
                             break;
                         }
                     }
                     if (check == false)
                     {
                         hddto.TienThuoc = float.Parse(lbltienthuoc.Text.ToString());
                         int n = hdbus.insert(hddto);
                         if (n > 0)
                         {
                             btnindonthuoc.Enabled = false;
                             checkBoxMuathuoc.Enabled = false;
                             btninhoadon.Enabled = true;
                             bnbus.showBNChuaLapHD(lvdsbenhnhan, bnbus.getListByPhieuKham(dtimengaykham.Text.ToString(), "in"), dtimengaykham.Text.ToString());
                         }
                         for (int i = 0; i < listctk.Length; i++)
                         {
                             ltdto = new LoaiThuocDTO();
                             ltdto.MaLoaiThuoc = listctk[i].MaLoaiThuoc;
                             ltdto.SoLuong = lbbus.getByPrimaryKey(ltdto.MaLoaiThuoc).SoLuong - listctk[i].SoLuong;
                             lbbus.updateSoLuong(ltdto);
                         }
                     }
                     else
                     {
                           DialogResult result2;
                           result2 = MessageBox.Show("Số lượng thuốc trong kho không đủ cho hóa đơn này, vui lòng nhập thuốc. Nếu muốn tiếp tục lập hóa đơn sẽ không bao gồm tiền thuốc trong hóa đơn này!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                             if (result2 == DialogResult.Yes)
                             {   hddto.TienThuoc = 0;
                                 lbltongcong.Text = lbltienkham.Text;
                                 checkBoxMuathuoc.Checked = false;
                                 int n = hdbus.insert(hddto);
                                 if (n > 0)
                                 {
                                     btnindonthuoc.Enabled = false;
                                     checkBoxMuathuoc.Enabled = false;
                                     btninhoadon.Enabled = true;
                                     bnbus.showBNChuaLapHD(lvdsbenhnhan, bnbus.getListByPhieuKham(dtimengaykham.Text.ToString(), "in"), dtimengaykham.Text.ToString());
                                 }
                             }
                     }
                 }
                 else
                 {
                     hddto.TienThuoc = 0;
                     lbltongcong.Text = lbltienkham.Text;
                     checkBoxMuathuoc.Checked = false;
                     int n = hdbus.insert(hddto);
                     if (n > 0)
                     {
                         btnindonthuoc.Enabled = false;
                         checkBoxMuathuoc.Enabled = false;
                         btninhoadon.Enabled = true;
                         bnbus.showBNChuaLapHD(lvdsbenhnhan, bnbus.getListByPhieuKham(dtimengaykham.Text.ToString(), "in"), dtimengaykham.Text.ToString());
                     }
                 }
             }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
           // bnbus.showInListView(lvdsbenhnhan, bnbus.getListByPhieuKham(dtimengaykham.Text.ToString(), "in"));
            bnbus.showBNChuaLapHD(lvdsbenhnhan, bnbus.getListByPhieuKham(dtimengaykham.Text.ToString(), "in"), dtimengaykham.Text.ToString());
        }

        private void btninhoadon_Click(object sender, EventArgs e)
        {
            KHAIBAO.mabenhnhan = lblmabenhnhan.Text.ToString();
            KHAIBAO.ngaykham = lblngaykham.Text.ToString();
            Presentation.frminhoadon frm = new frminhoadon();
            frm.ShowDialog();
           
        }
    }
}
