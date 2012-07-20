using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Data.SqlClient;

namespace QLPhongMachTu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnbenhnhan_Click(object sender, EventArgs e)
            {
                frmbenhnhan frmbenhnhan = new frmbenhnhan();
                frmbenhnhan.ShowDialog();       
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void btnthuoc_Click(object sender, EventArgs e)
        {
            Presentation.frmLoaiThuoc frm = new Presentation.frmLoaiThuoc();
            frm.ShowDialog();
        }

        private void btnloaibenh_Click(object sender, EventArgs e)
        {
            Presentation.frmloaibenh frm = new Presentation.frmloaibenh();
            frm.ShowDialog();
        }

        private void btncachdung_Click(object sender, EventArgs e)
        {
           
        }

        private void btndonvi_Click(object sender, EventArgs e)
        {
            Presentation.frmdonvi frm = new Presentation.frmdonvi();
            frm.ShowDialog();             
        }

        private void btndskb_Click(object sender, EventArgs e)
        {
            frmdanhsachkhambenh frm = new frmdanhsachkhambenh();
            frm.ShowDialog();
        }

        private void btnbaocaosudungthuoc_Click(object sender, EventArgs e)
        {
            
        }

        private void btndoanhthutheongay_Click(object sender, EventArgs e)
        {
            
        }

        private void btndtngay_Click(object sender, EventArgs e)
        {
            
        }

        private void btnbaocaothag_Click(object sender, EventArgs e)
        {
            
        }

        private void btnthaydoiquidinh_Click(object sender, EventArgs e)
        {
        }

        private void btndsk_Click(object sender, EventArgs e)
        {
            
        }
      
        private void buttonItem14_Click(object sender, EventArgs e)
        {         
         }

        private void buttonItem14_Click_1(object sender, EventArgs e)
        {     
        }

        private void btnqlhoadon_Click(object sender, EventArgs e)
        {
            Presentation.frmhoadon frm = new Presentation.frmhoadon();
            frm.ShowDialog();
        }

        private void btnphieukham_Click(object sender, EventArgs e)
        {
            Presentation.frmphieukhambenh frm = new Presentation.frmphieukhambenh();
            frm.ShowDialog();
        }

        private void btndsbb_Click(object sender, EventArgs e)
        {
           
        }

        private void btnhoadon_Click(object sender, EventArgs e)
        {

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            
        }

        private void btndonthuoc_Click(object sender, EventArgs e)
        {
            Presentation.frmdonthuoc frm = new Presentation.frmdonthuoc();
            frm.ShowDialog();
        }

        private void btndsbn_Click(object sender, EventArgs e)
        {
        }

        private void btndskhambenh_Click(object sender, EventArgs e)
        {
            
        }

        private void btndtn_Click(object sender, EventArgs e)
        {
            Presentation.frmbaocaothuoc frm = new Presentation.frmbaocaothuoc();
            frm.ShowDialog();
        }

        private void btnbct_Click(object sender, EventArgs e)
        {
           
        }

        private void btnhd_Click(object sender, EventArgs e)
        {
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {

        }
        private void btndangxuat_Click(object sender, EventArgs e)
        {
            
            
            
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnguoidung_Click(object sender, EventArgs e)
        {
            
        }

        private void btndoimk_Click(object sender, EventArgs e)
        {
            
        }

        private void btndoimatkhau_Click(object sender, EventArgs e)
        {
          
        }                  
        private void office2007StartButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
           
        }       
    }
}
