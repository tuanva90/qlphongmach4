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
    public partial class frmbaocaothuoc : Form
    {
        LoaiThuocBUS ltbus = new LoaiThuocBUS();
        PhieuKhamBenhBUS pkbus = new PhieuKhamBenhBUS();
        DSKBBUS dksbus = new DSKBBUS();
        HoaDonBUS hdbus = new HoaDonBUS();
        public frmbaocaothuoc()
        {
            InitializeComponent();
        }

        private void frmbaocaothuoc_Load(object sender, EventArgs e)
        {
            dtimengaykham.Text = DateTime.Now.ToShortDateString();
             baocaongay();
            ltbus.showBaoCaoThuocTheoNgay(lvbaocaothuoc, dtimengaykham.Text.ToString());
        }
        public void baocaongay()
        {
            float tienkham;
            float tienthuoc;
            lblngaykham.Text = dtimengaykham.Text.ToString();
            HoaDonDTO hddto;
            PhieuKhamBenhDTO[] dskbdto = pkbus.getListByNgayKham(dtimengaykham.Text.ToString());
            if (dskbdto != null)
            {
                tienkham = 0;
                tienthuoc = 0;
                lblsobenhnhan.Text = dskbdto.Length.ToString();
                for (int i = 0; i < dskbdto.Length; i++)
                {
                    hddto = hdbus.getByPrimaryKey(dskbdto[i].MaBenhNhan + dtimengaykham.Text.ToString());
                    if (hddto != null)
                    {
                        tienkham+=hddto.TienKham;
                        tienthuoc+=hddto.TienThuoc;
                    }
                }
                lbltienkham.Text = tienkham.ToString();
                lbltienthuoc.Text = tienthuoc.ToString();
                lbltongcong.Text = (tienthuoc + tienkham).ToString();
            }

        }

        private void dtimengaykham_Click(object sender, EventArgs e)
        {

        }

        private void dtimengaykham_TextChanged(object sender, EventArgs e)
        {
            ltbus.showBaoCaoThuocTheoNgay(lvbaocaothuoc, dtimengaykham.Text.ToString());
            lblngaykham.Text = "";
            lblsobenhnhan.Text = "";
            lbltienthuoc.Text = "";
            lbltienkham.Text = "";
            lbltongcong.Text = "";
            baocaongay();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
