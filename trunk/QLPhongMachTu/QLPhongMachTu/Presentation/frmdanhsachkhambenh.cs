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
using System.Text.RegularExpressions;

namespace QLPhongMachTu
{
    public partial class frmdanhsachkhambenh : Form
    {
        public frmdanhsachkhambenh()
        {
            InitializeComponent();
        }
        BenhNhanBUS bnbus = new BenhNhanBUS();
        BenhNhanDTO bndto = new BenhNhanDTO();
        DSKBBUS dskbbus = new DSKBBUS();
        DSKBDTO dskbdto = new DSKBDTO();
        BenhNhanDTO[] listbn;
        ThamSoBUS tsbus = new ThamSoBUS();
        private void mainForm_Load(object sender, EventArgs e)
        {
            dtimengaykham.Text = DateTime.Now.ToString();
            listbn = bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in");
            if (listbn == null)
                lblsoluong.Text = "0/" + tsbus.getThamSo().SoBenhNhanToiDa.ToString();
            else
                lblsoluong.Text = listbn.Length.ToString() + "/" + tsbus.getThamSo().SoBenhNhanToiDa.ToString();
            bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "not in"));
           // bnbus.showInListView(lvdskhambenh, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"));
            bnbus.showBNChuaLapPhieuKham(lvdskhambenh, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"), dtimengaykham.Text.ToString());
        }

        private void lvdskhambenh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvdskhambenh.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvdskhambenh.SelectedItems[0];
                mabn = lvi.SubItems[1].Text;
                btnthemvaodskb.Enabled = false;
                btnxoa.Enabled = true;              
               
            }
            if (dtimengaykham.Text.Equals(DateTime.Now.ToShortDateString().ToString()) == false)
            {
                btnthemvaodskb.Enabled = false;
                btnxoa.Enabled = false;

            }
            else
            {
                btnxoa.Enabled = true;
            }
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.ToShortDateString().ToString().Equals(dtimengaykham.Text.ToString()) == false)
            {                
                MessageBox.Show(" Chỉ có thể tạo danh sách khám bệnh cho ngày hôm nay ! ");
            }
            else
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
                    if (re1.IsMatch(txtnamsinh.Text) == false && txtnamsinh.Text!="")
                    {
                        MessageBox.Show("Định dạng năm sinh chưa đúng !");
                        txtsodienthoai.Focus();
                    }
                    else
                    {
                        bndto.MaBenhNhan = bnbus.getMaBN();
                        bndto.HoTen = txthotenbenhnhan.Text.ToString();
                        bndto.GioiTinh = cmbgioitinh.Text.ToString();
                        bndto.NamSinh = txtnamsinh.Text.ToString();
                        bndto.SoDienThoai = txtsodienthoai.Text.ToString();
                        bndto.DiaChi = txtdiachi.Text.ToString();
                        if (bnbus.insert(bndto) > 0)
                        {
                            dskbdto.NgayKham = dtimengaykham.Text.ToString();
                            dskbdto.MaBenhNhan = bndto.MaBenhNhan;
                            dskbbus.insert(dskbdto);
                            bnbus.showBNChuaLapPhieuKham(lvdskhambenh, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"), dtimengaykham.Text.ToString());
                            bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "not in"));// do danh sach bn chua co trong dskb len lvdskb
                            txtmabenhnhan.Text = "";
                            txthotenbenhnhan.Text = "";
                            txtmabenhnhan.Text = "";
                            txthoten.Text = "";
                            cmbgioitinh.Text = "";
                            txtnamsinh.Text = "";
                            txtsodienthoai.Text = "";
                            txtdiachi.Text = ""; 
                        }
                    }
                }
               
            }            
        }

        private void btnthemvaodskb_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.ToShortDateString().ToString().Equals(dtimengaykham.Text.ToString()) == false)
            {
                MessageBox.Show(" Chỉ có thể tạo danh sách khám bệnh cho ngày hôm nay ! ");
            }
            else
            {
                listbn = bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in");
                 if (listbn != null && listbn.Length > int.Parse(tsbus.getThamSo().SoBenhNhanToiDa.ToString()))
                 {
                     MessageBox.Show(" Số bệnh nhân tới khám tối đa trong ngày là : " + tsbus.getThamSo().SoBenhNhanToiDa.ToString() + " người ! ");
                 }
                 else
                 {
                     dskbdto.NgayKham = dtimengaykham.Text.ToString();
                     dskbdto.MaBenhNhan = mabn;
                     dskbbus.insert(dskbdto);
                     // cap nhat lvdskham benh và lvdsbenhnhan
                     bnbus.showBNChuaLapPhieuKham(lvdskhambenh, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"), dtimengaykham.Text.ToString());
                     bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "not in"));//
                     btnxoa.Enabled = false;
                     lblsoluong.Text = listbn.Length.ToString() + "/" + tsbus.getThamSo().SoBenhNhanToiDa.ToString();
                 }
            }
            txtmabn.Text = "";
            txthoten.Text = "";
            lblsoluong.Text = bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in").Length.ToString() + "/" + tsbus.getThamSo().SoBenhNhanToiDa.ToString();
        }

        string mabn;
        private void lvdsbenhnhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvdsbenhnhan.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvdsbenhnhan.SelectedItems[0];
                mabn = lvi.SubItems[1].Text;
                btnthemvaodskb.Enabled = true;
                btnxoa.Enabled = false;
             }
            if (dtimengaykham.Text.Equals(DateTime.Now.ToShortDateString().ToString()) == false)
            {
                btnthemvaodskb.Enabled = false;
                btnxoa.Enabled = false;
            }
            else
            {
                btnthemvaodskb.Enabled = true;
            }

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.ToShortDateString().ToString().Equals(dtimengaykham.Text.ToString()) == false)
            {
                MessageBox.Show(" Chỉ có thể xóa bệnh nhân khỏi danh sách khám bệnh trong hôm nay ! ");
            }
            else
            {
                listbn = bnbus.getListByPhieuKham(dtimengaykham.Text.ToString(), "in");
                dskbdto.NgayKham = dtimengaykham.Text.ToString();
                dskbdto.MaBenhNhan = mabn;
                if (listbn != null)
                {

                    // kiem tra xem benh nhan da duoc lap phieu kham chua, neu da lap phieu kham roi thi k the xoa khoi danh sach kham benh !
                    bool result = false;
                    for (int i = 0; i < listbn.Length; i++)
                    {
                        if (listbn[i].MaBenhNhan == dskbdto.MaBenhNhan)
                        {
                            result = true;
                            break;
                        }
                    }
                    if (result == false)
                    {
                        dskbbus.delete(dskbdto);
                        // cap nhat lvdskham benh và lvdsbenhnhan
                        bnbus.showBNChuaLapPhieuKham(lvdskhambenh, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"), dtimengaykham.Text.ToString());
                        bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "not in"));//
                        
                        lblsoluong.Text =  bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in").Length.ToString() + "/" + tsbus.getThamSo().SoBenhNhanToiDa.ToString();
                    }
                    else
                        MessageBox.Show(" Bệnh nhân này đã được lập phiếu khám, không thể xóa !");
                    btnthemvaodskb.Enabled = false;
                }
                else
                {
                    dskbbus.delete(dskbdto);
                    // cap nhat lvdskham benh và lvdsbenhnhan
                    bnbus.showBNChuaLapPhieuKham(lvdskhambenh, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"), dtimengaykham.Text.ToString());
                    bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "not in"));//
                    lblsoluong.Text = bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in").Length.ToString() + "/" + tsbus.getThamSo().SoBenhNhanToiDa.ToString();
                }
            }
            txtmabn.Text = "";
            txthoten.Text = "";
        }

        private void dtimengaykham_Click(object sender, EventArgs e)
        {
           
        }

        private void dtimengaykham_TextChanged(object sender, EventArgs e)
        {
            // cap nhat lvdskham benh và lvdsbenhnhan
            bnbus.showBNChuaLapPhieuKham(lvdskhambenh, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"), dtimengaykham.Text.ToString());
            bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "not in"));//
            if (DateTime.Now.ToShortDateString().ToString().Equals(dtimengaykham.Text.ToString()) == false)
            {
                btnthemvaodskb.Enabled = false;
                btnxoa.Enabled = false;
                btnthem.Enabled = false;
            }
            else
                btnthem.Enabled = true;
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
                bnbus.showInListView(lvdsbenhnhan, bnbus.getList());
            }
            else
                bnbus.showInListView(lvdsbenhnhan, bnbus.getByPrimaryKey(txtmabn.Text.ToString()));
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
                bnbus.showInListView(lvdsbenhnhan, bnbus.getList());
            }
            else
                bnbus.showInListView(lvdsbenhnhan, bnbus.getByHoTen(txthoten.Text.ToString()));
        }

        private void txtsodienthoai_TextChanged(object sender, EventArgs e)
        {
            //Regex re = new Regex(@"0\d{9,10}");
            //if (re.IsMatch(txtsodienthoai.Text) == false && txtsodienthoai.Text != "")
            //{
            //    MessageBox.Show(" Số điện thoại không đúng !");
            //    txtsodienthoai.Clear();
            //}   

        }

        private void txtnamsinh_TextChanged(object sender, EventArgs e)
        {
            Regex re = new Regex(@"^[\w\s]+$");
            if (re.IsMatch(txtnamsinh.Text) == false && txtnamsinh.Text != "")
            {
                MessageBox.Show(" Bạn vừa nhập kí tự đặc biệt, nhập lai !");
                txtnamsinh.Clear();
            }  
        }

        private void txtsodienthoai_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
