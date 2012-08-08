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
    public partial class frminphieukham : Form
    {
        HoaDonBUS hdbus = new HoaDonBUS();
        CT_KhamBUS ctkbus = new CT_KhamBUS();
        CachDungBUS cdbus = new CachDungBUS();
        LoaiThuocBUS ltbus = new LoaiThuocBUS();
        DonViBUS dvbus = new DonViBUS();
        PhieuKhamBenhBUS pkbus = new PhieuKhamBenhBUS();
        public frminphieukham()
        {
            InitializeComponent();
        }
        ReportDocument cr;
        private void frminhoadon_Load(object sender, EventArgs e)
        {
            DataTable ds = hdbus.getHoaDon(KHAIBAO.mabenhnhan, KHAIBAO.ngaykham);
            ds.TableName = "HoaDon";
            DataTable dt2 = ctkbus.getDonThuoc(KHAIBAO.mabenhnhan + KHAIBAO.ngaykham);
            dt2.TableName = "DonThuoc";
            DataTable dt3 = cdbus.getCachDung();
            dt3.TableName = "CachDung";
            DataTable dt4 = ltbus.getLoaiThuoc();
            dt4.TableName = "LoaiThuoc";
            DataTable dt5 = dvbus.getDonVi();
            dt5.TableName = "DonVi";
            DataTable dt6 = pkbus.getPhieuKham(KHAIBAO.ngaykham);
            dt6.TableName = "PhieuKham";
            DataSet dts = new DataSet();
            dts.Tables.Add(ds);
            dts.Tables.Add(dt2);
            dts.Tables.Add(dt3);
            dts.Tables.Add(dt4);
            dts.Tables.Add(dt5);
            dts.Tables.Add(dt6);
         
                ReportDocument report = new ReportDocument();
                report.Load("..\\..\\inphieukham.rpt");
                report.SetDataSource(dts);
                crystalReportViewer.ReportSource = report;
                inphieukham dt = new inphieukham();
           
         }
    }
}
