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
        public frmbaocaothuoc()
        {
            InitializeComponent();
        }

        private void frmbaocaothuoc_Load(object sender, EventArgs e)
        {
            dtimengaykham.Text = DateTime.Now.ToShortDateString();
            ltbus.showBaoCaoThuocTheoNgay(lvbaocaothuoc, dtimengaykham.Text.ToString());
        }

        private void dtimengaykham_Click(object sender, EventArgs e)
        {

        }

        private void dtimengaykham_TextChanged(object sender, EventArgs e)
        {
            ltbus.showBaoCaoThuocTheoNgay(lvbaocaothuoc, dtimengaykham.Text.ToString());
        }
    }
}
