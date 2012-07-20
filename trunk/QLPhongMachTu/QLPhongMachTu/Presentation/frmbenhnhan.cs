using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Text.RegularExpressions;


namespace QLPhongMachTu
{
    public partial class frmbenhnhan : Form
    {
        BenhNhanBUS bnbus = new BenhNhanBUS();
        BenhNhanDTO bndto = new BenhNhanDTO();
        public frmbenhnhan()
        {
            InitializeComponent();
        }      
        private void frmbenhnhan_Load(object sender, EventArgs e)
        {
            bnbus.showInListView(lvDanhSachBenhNhan, bnbus.getList());
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
         }

        private void btnthembenhnhan_Click(object sender, EventArgs e)
        {
            Regex re = new Regex(@"0\d{9,10}");
            if (re.IsMatch(txtsodienthoai.Text) == false && txtsodienthoai.Text != "")
            {
                MessageBox.Show(" Định dạng số điện thoại chưa đúng !");
                txtsodienthoai.Focus();
            }
            else
            {
                Regex re1 = new Regex(@"^[1-2]\d{3}");
                if (re1.IsMatch(txtnamsinh.Text) == false && txtnamsinh.Text != "")
                {
                    MessageBox.Show("Định dạng năm sinh chưa đúng !");
                    txtnamsinh.Focus();
                }
                else
                {
                    bndto.HoTen = txthotenbenhnhan.Text.ToString();
                    bndto.GioiTinh = cmbgioitinh.Text.ToString();
                    bndto.NamSinh = txtnamsinh.Text.ToString();
                    bndto.SoDienThoai = txtsodienthoai.Text.ToString();
                    bndto.DiaChi = txtdiachi.Text.ToString();
                    bnbus.insert(bndto);
                    bnbus.showInListView(lvDanhSachBenhNhan, bnbus.getList());
                    btnthembenhnhan.Enabled = true;
                    btnxoa.Enabled = false;
                    btnsua.Enabled = false;
                }
            }
        }
        public void refresh()
        {
            txtmabenhnhan.Text = "";
            txthotenbenhnhan.Text = "";
            txtmabenhnhan.Text = "";
            txthoten.Text = "";
            cmbgioitinh.Text = "";
            txtnamsinh.Text = "";
            txtsodienthoai.Text = "";
            txtdiachi.Text = ""; 
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            bnbus.delete(txtmabenhnhan.Text.ToString());
            btnthembenhnhan.Enabled = true;
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            refresh();
            bnbus.showInListView(lvDanhSachBenhNhan, bnbus.getList());

        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            bndto.MaBenhNhan = txtmabenhnhan.Text.ToString();
            bndto.HoTen = txthotenbenhnhan.Text.ToString();
            bndto.GioiTinh = cmbgioitinh.Text.ToString();
            bndto.NamSinh = txtnamsinh.Text.ToString();
            bndto.SoDienThoai = txtsodienthoai.Text.ToString();
            bndto.DiaChi = txtdiachi.Text.ToString();
            bnbus.update(bndto);
            bnbus.showInListView(lvDanhSachBenhNhan, bnbus.getList());
        }
       
        private void btnluu_Click(object sender, EventArgs e)
        {                         
                  
        }
        
        private void btnhuy_Click(object sender, EventArgs e)
        {             
              
        }
        
        private void dtgrvdanhsachkhambenh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }       

        private void btnthoat_Click(object sender, EventArgs e)
        {
            btnthembenhnhan.Enabled = true;
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            refresh();
        
        }
        private void btnthemvaodskb_Click(object sender, EventArgs e)
        {

           }
        private void rdbnkhamlandau_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void rdbnkhamnhieulan_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void btnokmbn_Click(object sender, EventArgs e)
        {
            bnbus.showInListView(lvDanhSachBenhNhan, bnbus.getByPrimaryKey(txtmabn.Text.ToString()));
        }

        private void btnokhoten_Click(object sender, EventArgs e)
        {
            
        }

        private void txthotenbenhnhan_TextChanged(object sender, EventArgs e)
        {
            Regex re = new Regex(@"^[\w\s]+$");
            if (re.IsMatch(txthotenbenhnhan.Text) == false && txthotenbenhnhan.Text != "")
            {
                MessageBox.Show(" Bạn vừa nhập kí tự đặc biệt, nhập lai !");
                txthotenbenhnhan.Clear();
            }   
        }

        private void txtdiachi_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtmabn_TextChanged(object sender, EventArgs e)
        {

            Regex re = new Regex(@"^[\w\s]+$");
            if (re.IsMatch(txtmabn.Text) == false && txtmabn.Text != "")
            {
                MessageBox.Show(" Bạn vừa nhập kí tự đặc biệt, nhập lai !");
                txtmabn.Clear();
            }
            if (txtmabn.Text == "")
            {
                bnbus.showInListView(lvDanhSachBenhNhan, bnbus.getList());
            }
            else
            bnbus.showInListView(lvDanhSachBenhNhan, bnbus.getByPrimaryKey(txtmabn.Text.ToString()));
        }

        private void txthoten_TextChanged(object sender, EventArgs e)
        {
            Regex re = new Regex(@"^[\w\s]+$");
            if (re.IsMatch(txthoten.Text) == false && txthoten.Text != "")
            {
                MessageBox.Show(" Bạn vừa nhập kí tự đặc biệt, nhập lai !");
                txthoten.Clear();
            }
            if (txthoten.Text == "")
            {
                bnbus.showInListView(lvDanhSachBenhNhan, bnbus.getList());
            }
            else
                bnbus.showInListView(lvDanhSachBenhNhan, bnbus.getByHoTen(txthoten.Text.ToString()));
        }

        private void cmbgioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvDanhSachBenhNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvDanhSachBenhNhan.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvDanhSachBenhNhan.SelectedItems[0];
                txtmabenhnhan.Text = lvi.SubItems[1].Text;
                txthotenbenhnhan.Text = lvi.SubItems[2].Text;
                cmbgioitinh.Text = lvi.SubItems[3].Text;
                txtnamsinh.Text = lvi.SubItems[4].Text;
                txtsodienthoai.Text = lvi.SubItems[5].Text;
                txtdiachi.Text = lvi.SubItems[6].Text;               
            }
            else
            {
                refresh();  
            }
            btnthembenhnhan.Enabled = false;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
        }

        private void txtnamsinh_TextChanged(object sender, EventArgs e)
        {
            Regex re = new Regex(@"^[\w\s]+$");
            if (re.IsMatch(txthotenbenhnhan.Text) == false && txthotenbenhnhan.Text != "")
            {
                MessageBox.Show(" Bạn vừa nhập kí tự đặc biệt, nhập lai !");
                txtnamsinh.Clear();
            }   
        }

        private void txtsodienthoai_TextChanged(object sender, EventArgs e)
        {
            
        }       
    }
}
