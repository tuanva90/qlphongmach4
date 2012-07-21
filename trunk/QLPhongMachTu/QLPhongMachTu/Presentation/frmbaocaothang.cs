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
    public partial class frmbaocaothang : Form
    {
        LoaiThuocBUS ltbus = new LoaiThuocBUS();
        PhieuKhamBenhBUS pkbus = new PhieuKhamBenhBUS();
        DSKBBUS dksbus = new DSKBBUS();
        HoaDonBUS hdbus = new HoaDonBUS();
        public frmbaocaothang()
        {
            InitializeComponent();
        }

        private void frmbaocaothang_Load(object sender, EventArgs e)
        {
            cmbthang.Text = "1";
            cmbnam.Text = "2012";
            baocaothang();
            ltbus.showBaoCaoThang(lvbaocaothuoc,int.Parse(cmbthang.Text.ToString()),int.Parse(cmbnam.Text.ToString()));
        }
        public void baocaothang()
        {
            float tienkham;
            float tienthuoc;
            lblngaykham.Text = cmbthang.Text.ToString() + "/" + cmbnam.Text.ToString();
            HoaDonDTO hddto;
            HoaDonDTO[] dskbdto = hdbus.getBaoCaoThang(int.Parse(cmbthang.Text.ToString()),int.Parse(cmbnam.Text.ToString()));
            if (dskbdto != null)
            {
                tienkham = 0;
                tienthuoc = 0;
                lblsobenhnhan.Text = dskbdto.Length.ToString();
                for (int i = 0; i < dskbdto.Length; i++)
                {
                    hddto = hdbus.getByPrimaryKey(dskbdto[i].MaPhieuKhamBenh + "");
                    if (hddto != null)
                    {
                        tienkham += hddto.TienKham;
                        tienthuoc += hddto.TienThuoc;
                    }
                }
                lbltienkham.Text = tienkham.ToString();
                lbltienthuoc.Text = tienthuoc.ToString();
                lbltongcong.Text = (tienthuoc + tienkham).ToString();
            }

        }

        private void cmbthang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblngaykham.Text = "";
                lblsobenhnhan.Text = "";
                lbltienthuoc.Text = "";
                lbltienkham.Text = "";
                lbltongcong.Text = "";
                baocaothang();
                ltbus.showBaoCaoThang(lvbaocaothuoc, int.Parse(cmbthang.Text.ToString()), int.Parse(cmbnam.Text.ToString()));
            }
            catch
            {
            }
        }

        private void cmbnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbthang_SelectedIndexChanged(sender, e);
        }
    }
}
