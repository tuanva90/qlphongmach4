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
        private void mainForm_Load(object sender, EventArgs e)
        {
            dtimengaykham.Text = DateTime.Now.ToString();
            bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "not in"));
            bnbus.showInListView(lvdskhambenh, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in"));
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
                bndto.MaBenhNhan = bnbus.getMaBN();
                bndto.HoTen = txthotenbenhnhan.Text.ToString();
                bndto.GioiTinh = cmbgioitinh.Text.ToString();
                bndto.NamSinh = txtnamsinh.Text.ToString();
                bndto.SoDienThoai = txtsodienthoai.Text.ToString();
                bndto.DiaChi = txtdiachi.Text.ToString();
                bnbus.insert(bndto);
                dskbdto.NgayKham = dtimengaykham.Text.ToString();
                dskbdto.MaBenhNhan = bndto.MaBenhNhan;
                dskbbus.insert(dskbdto);
                bnbus.showInListView(lvdskhambenh, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in")); // do danh sach benh nhan da co trong danh sach kham benh len lvdskb
                bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "not in"));// do danh sach bn chua co trong dskb len lvdskb
               
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
                dskbdto.NgayKham = dtimengaykham.Text.ToString();
                dskbdto.MaBenhNhan = mabn;
                dskbbus.insert(dskbdto);
                // cap nhat lvdskham benh và lvdsbenhnhan
                bnbus.showInListView(lvdskhambenh, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in")); // 
                bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "not in"));//
                btnxoa.Enabled = false;
            }
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

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.ToShortDateString().ToString().Equals(dtimengaykham.Text.ToString()) == false)
            {
                MessageBox.Show(" Chỉ có thể xóa bệnh nhân khỏi danh sách khám bệnh trong hôm nay ! ");
            }
            else
            {
                dskbdto.NgayKham = dtimengaykham.Text.ToString();
                dskbdto.MaBenhNhan = mabn;
                dskbbus.delete(dskbdto);
                // cap nhat lvdskham benh và lvdsbenhnhan
                bnbus.showInListView(lvdskhambenh, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in")); // 
                bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "not in"));//
                btnthemvaodskb.Enabled = false;
            }
        }

        private void dtimengaykham_Click(object sender, EventArgs e)
        {
           
        }

        private void dtimengaykham_TextChanged(object sender, EventArgs e)
        {
            // cap nhat lvdskham benh và lvdsbenhnhan
            bnbus.showInListView(lvdskhambenh, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "in")); // 
            bnbus.showInListView(lvdsbenhnhan, bnbus.getListByDSKB(dtimengaykham.Text.ToString(), "not in"));//
            if (DateTime.Now.ToShortDateString().ToString().Equals(dtimengaykham.Text.ToString()) == false)
            {
                btnthemvaodskb.Enabled = false;
                btnthem.Enabled = false;
                btnxoa.Enabled = false;
            }
        }
    }
}
