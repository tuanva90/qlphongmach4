using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;


namespace QLPhongMachTu
{
    public partial class frmthaydoiquidinh : Form
    {
        ThamSoBUS ts = new ThamSoBUS();
        public frmthaydoiquidinh()
        {
            InitializeComponent();
        }

        private void frmthaydoiquidinh_Load(object sender, EventArgs e)
        {
          
            btnhuysobn.Enabled = false;
            txtsobn.Text = ts.getThamSo().SoBenhNhanToiDa.ToString();
            txttienkham.Text = ts.getThamSo().TienKham.ToString();
            btnoktk.Visible = false;
            btnok.Visible = false;
            btnsuasbn.Visible = true;
        }       

        private void btnsuatk_Click(object sender, EventArgs e)
        {
            btnsuatk.Visible = false;
            btnoktk.Visible = true;
            txttienkham.Enabled = true;
            txttienkham.Focus();
            btnhuy.Visible = true;
        //    btnhuy.Enabled = true;
        //    btnsuatk.Text = "OK";
        //    txttienkham.Enabled = true;
        //    txttienkham.Focus();
        //    try
        //    {
        //        float a = float.Parse(txttienkham.Text.ToString());
        //        if (btnsuatk.Text == "OK")
        //        {
        //            ts.Updatetienkham(a);
        //            btnsuatk.Text = "Sửa";
        //            btnsuatk.Enabled = false;
        //            txttienkham.Enabled = false;
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show(" Định dạng tiền khám chưa đúng ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txttienkham.Focus();
        //    }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnsuatk.Visible = true;
            btnoktk.Visible = false;
            btnhuy.Visible = false;
            txttienkham.Text = ts.getThamSo().TienKham.ToString();
            txttienkham.Enabled = false;
        }

        private void btnsuabn_Click(object sender, EventArgs e)
        {
            btnsuasbn.Visible = false;
            btnok.Visible = true;
            btnhuysobn.Enabled = false;
            txtsobntoida.Enabled = false;
            txtsobntoida.Focus();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtsobn.Text.ToString());
                if (a < 0)
                {
                    MessageBox.Show(" Số lượng bệnh nhân tối đa không được âm ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtsobntoida.Text = "";
                    txtsobntoida.Focus();
                }
                else
                {
                    
                    btnsuasobn.Visible = true;
                    btnok.Visible = false;
                    btnhuybn.Visible = false;
                    ts.updateSLTD(a);
                    txtsobn.Text = ts.getThamSo().SoBenhNhanToiDa.ToString();
                    txtsobn.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show(" Định dạng số lượng chưa đúng ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsobntoida.Text = "";
                txtsobntoida.Focus();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            btnok.Visible = false;
            btnsuasbn.Visible = true;
            txtsobntoida.Enabled = false;
            txtsobntoida.Text = ts.getThamSo().SoBenhNhanToiDa.ToString();
        }

        private void btnoktk_Click(object sender, EventArgs e)
        {
            try
            {
                float a = float.Parse(txttienkham.Text.ToString());
                if (a < 0)
                {
                    MessageBox.Show(" Giá khám không được âm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtsobntoida.Focus();
                }
                else
                {
                    ts.updateTienKham(a);
                    btnoktk.Visible = false;
                    txttienkham.Enabled = false;
                    btnsuatk.Visible = true;
                    btnhuy.Visible = false;
                    txttienkham.Text = ts.getThamSo().TienKham.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(" Định dạng tiền khám chưa đúng ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttienkham.Text = "";
                txttienkham.Focus();
            }
        }

        private void btnsuabn_Click_1(object sender, EventArgs e)
        {
            txtsobn.Enabled = true;
            txtsobn.Focus();
            btnok.Visible = true;
            btnsuasbn.Visible = false;
            btnhuybn.Enabled = true;
        }

        private void btnhuybn_Click(object sender, EventArgs e)
        {         
            btnsuasobn.Visible = true;
            btnhuybn.Visible = false;
            btnok.Visible = false;
            txtsobn.Text = ts.getThamSo().SoBenhNhanToiDa.ToString();
            txtsobn.Enabled = false;
        }

        private void txtsobn_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsuasobn_Click(object sender, EventArgs e)
        {           
            txtsobn.Enabled = true;
            txtsobn.Focus();
            btnsuasbn.Enabled = true;
            btnsuasbn.Visible = false;
            btnok.Visible = true;
            btnhuybn.Visible = true;
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            btnsuasobn.Visible = false;
            btnok.Visible = true;
            btnhuybn.Visible = true;
            txtsobn.Enabled = true;
            txtsobn.Focus();
        }   
              
    }
}
