using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using BUS;
using DTO;
namespace QLPhongMachTu.Presentation
{
    public partial class frminhoadon : Form
    {
        HoaDonBUS hdbus = new HoaDonBUS();
        public frminhoadon()
        {
            InitializeComponent();
        }
        ReportDocument cr;
        private void frminhoadon_Load(object sender, EventArgs e)
        {
            //DataSet ds = hdbus.getHoaDon(KHAIBAO.mabenhnhan,KHAIBAO.ngaykham);
            //ReportDocument report = new ReportDocument();
            //report.Load("..\\..\\inhoadon.rpt");
            //report.SetDataSource(ds);
            //crystalReportViewer.ReportSource = report;
         //   inhoadon dt = new inhoadon();
            dtshoadon dt = new dtshoadon();
           
            dt.Tables.Add(hdbus.getHoaDon(KHAIBAO.mabenhnhan,KHAIBAO.ngaykham));
            cr = new inhoadon();
            cr.SetDataSource(dt.Tables[1]);
            crystalReportViewer.ReportSource = cr;
        }
    }
}
