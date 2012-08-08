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
        public static NguoiDungDTO user = null;
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
            disableAllFunction();
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
            new frmthaydoiquidinh().ShowDialog();
        }

        private void btndsk_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            SqlConnection.ClearAllPools();
            DialogResult result;
            result = MessageBox.Show("Bạn có thật sự muốn phục hổi dữ liệu ?", " Chú ý ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //if (bk.Restore())
                //    MessageBox.Show("Phục hồi thành công ");
                //else
                //    MessageBox.Show("Phục hồi thất bại");
                string str1 = Path.GetFullPath("PhongMachTu.mdf");
                string str2 = Path.GetFullPath("PhongMachTu_log.ldf");
                string str_mdf = @"";
                for (int i = 0; i < str1.Length - 15; i++)
                {
                    str_mdf += str1[i];
                }
                str_mdf += "Database\\PhongMachTu.mdf";
                string str_ldf = @"";
                for (int i = 0; i < str2.Length - 19; i++)
                {
                    str_ldf += str2[i];
                }
                str_ldf += "Database\\PhongMachTu_log.ldf";

                if (File.Exists(str_mdf))
                    File.Delete(str_mdf);
                if (File.Exists(str_ldf))
                    File.Delete(str_ldf);
                string str_mdf_save = @"";
                for (int i = 0; i < str1.Length - 15; i++)
                {
                    str_mdf_save += str1[i];
                }
                str_mdf_save += "Save\\";
                File.Copy(str_mdf_save + "Database\\PhongMachTu.mdf", str_mdf);
                File.Copy(str_mdf_save + "Database\\PhongMachTu_log.ldf", str_ldf);
                MessageBox.Show(" Phục hồi dữ liệu thành công");
            }            
        }

        private void buttonItem14_Click_1(object sender, EventArgs e)
        {
            SqlConnection.ClearAllPools();
            DialogResult result;
            result = MessageBox.Show("Bạn có thật sự muốn sao lưu dữ liệu ?", " Chú ý ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //if (bk.Backup())
                //    MessageBox.Show("Sao lưu thành công ");
                //else
                //    MessageBox.Show("Sao lưu thất bại");
                string str1 = Path.GetFullPath("PhongMachTu.mdf");
                string str2 = Path.GetFullPath("PhongMachTu_log.ldf");
                string str_mdf = @"";
                for (int i = 0; i < str1.Length-15; i++)
                {
                    str_mdf += str1[i];
                }
                str_mdf += "Database\\PhongMachTu.mdf";
                string str_ldf = @"";
                for (int i = 0; i < str2.Length - 19; i++)
                {
                    str_ldf += str2[i];
                }
                str_ldf += "Database\\PhongMachTu_log.ldf";
                string str_mdf_save = @"";
                for (int i = 0; i < str1.Length - 15; i++)
                {
                    str_mdf_save += str1[i];
                }
                str_mdf_save += "Save\\";
                if (File.Exists(str_mdf_save + "Database\\PhongMachTu.mdf"))
                    File.Delete(str_mdf_save + "Database\\PhongMachTu.mdf");
                if (File.Exists(str_mdf_save + "Database\\PhongMachTu_log.mdf"))
                    File.Delete(str_mdf_save + "Database\\PhongMachTu_log.ldf");
                File.Copy(str_mdf, str_mdf_save + "Database\\PhongMachTu.mdf");
                File.Copy(str_ldf, str_mdf_save + "Database\\PhongMachTu_log.ldf");
                MessageBox.Show("Sao lưu thành công");
            }                   
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
            Presentation.frmtimkiem frm = new Presentation.frmtimkiem();
            frm.ShowDialog();
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
            Presentation.frmbaocaothang frm = new Presentation.frmbaocaothang();
            frm.ShowDialog();
        }

        private void btnhd_Click(object sender, EventArgs e)
        {
        }

        private void disableAllFunction()
        {
            btnbenhnhan.Enabled = false;
            btnthuoc.Enabled = false;
            btnloaibenh.Enabled = false;
            btndonvi.Enabled = false;
            btndskb.Enabled = false;
            btnqlhoadon.Enabled = false;
            btnphieukham.Enabled = false;
            btndonthuoc.Enabled = false;

            rdthongke.Enabled = false;
            btnbct.Enabled = false;
            btndtn.Enabled = false;

            rdtimkiem.Enabled = false;
            btntimkiem.Enabled = false;

            rdnguoidung.Enabled = false;
            btnnguoidung.Enabled = false;
            btndoimk.Enabled = false;

            rdquidinh.Enabled = false;
            btnthaydoiquidinh.Enabled = false;

            rdsaoluu_phuchoi.Enabled = false;
            btnsaoluu.Enabled = false;
            btnphuchoi.Enabled = false;

            btnnguoidung.Enabled = false;
            btndoimk.Enabled = false;
        }

        private void enableallfunction()
        {
            //rbtabquanly.Enabled = true;
            //
            //
            //
            //rdtimkiem.Enabled = true;
            //rdtimkiembenhnhan.Enabled = true;
            btnbenhnhan.Enabled = true;
            btnthuoc.Enabled = true;
            btnloaibenh.Enabled = true;            
            btndonvi.Enabled = true;           
            btndskb.Enabled = true;
            btnqlhoadon.Enabled = true;
            btnphieukham.Enabled = true;
            btndonthuoc.Enabled = true;

            rdthongke.Enabled = true;
            btnbct.Enabled = true;
            btndtn.Enabled = true;

            rdtimkiem.Enabled = true;
            btntimkiem.Enabled = true;                     

            rdquidinh.Enabled = true;
            btnthaydoiquidinh.Enabled = true;

            rdsaoluu_phuchoi.Enabled = true;
            btnsaoluu.Enabled = true;
            btnphuchoi.Enabled = true;


            rdnguoidung.Enabled = true;
            btnnguoidung.Enabled = true;
            btndoimk.Enabled = true;
        }

        private void enablefunctionforbacsi()
        {
            //btnbenhnhan.Enabled = true;
            //btnthuoc.Enabled = true;
            //btnloaibenh.Enabled = true;
            //btncachdung.Enabled = true;
            //btndonvi.Enabled = true;
            //btndsbn.Enabled = true;
            //btnqlhoadon.Enabled = true;
            btnphieukham.Enabled = true;
            btndonthuoc.Enabled = true;

            rdtimkiem.Enabled = true;
            btntimkiem.Enabled = true;

            //btnnguoidung.Enabled = true;
            rdnguoidung.Enabled = true;
            btndoimk.Enabled = true;
        }

        private void enablefunctionforyta()
        {
            btnbenhnhan.Enabled = true;
            //btnthuoc.Enabled = true;
            //btnloaibenh.Enabled = true;
            //btncachdung.Enabled = true;
            //btndonvi.Enabled = true;
            
            btndskb.Enabled = true;
            btnqlhoadon.Enabled = true;
            //btnphieukham.Enabled = true;
            btndonthuoc.Enabled = true;

            //rdthongke.Enabled = true;

            //rdquidinh.Enabled = true;

            //rdsaoluu_phuchoi.Enabled = true;

            rdtimkiem.Enabled = true;
            btntimkiem.Enabled = true;

            //btnnguoidung.Enabled = true;
            rdnguoidung.Enabled = true;
            btndoimk.Enabled = true;
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            new Presentation.frmdangnhap().ShowDialog();
            if (user != null)
            {
                if (user.MaPhanQuyen == 1) //Admin
                    enableallfunction();
                else if (user.MaPhanQuyen == 2) //Basi
                    enablefunctionforbacsi();
                else if (user.MaPhanQuyen == 3) //Yta
                    enablefunctionforyta();
                else
                {
                }
                btndangnhap.Enabled = false;
                btndangxuat.Enabled = true;
                MessageBox.Show("Chúc mừng bạn đã đăng nhập thành công!", "Thông báo");
            }
            else
                MessageBox.Show("Đăng nhập thất bại!", "Thông báo");
        }
        private void btndangxuat_Click(object sender, EventArgs e)
        {
            btndangxuat.Enabled = false;
            btndangnhap.Enabled = true;
            disableAllFunction();
            user = null;
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnguoidung_Click(object sender, EventArgs e)
        {
            new Presentation.frmquanlynguoidung().ShowDialog();
        }

        private void btndoimk_Click(object sender, EventArgs e)
        {
            new Presentation.frmdoimatkhau().ShowDialog();
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
