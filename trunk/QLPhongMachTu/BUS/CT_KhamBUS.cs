using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data;
using System.Windows.Forms;
namespace BUS
{
   public class CT_KhamBUS
    {
        private CT_KhamDAO dvdao = new CT_KhamDAO();
        private CachDungDAO cddao = new CachDungDAO();
        private LoaiThuocDAO tdao = new LoaiThuocDAO();
        private DonViDAO donvidao = new DonViDAO();    
        public void showInListView(ListView lv, CT_KhamDTO[] listbn)
        {
            if (lv.Items.Count > 0)
                lv.Items.Clear();
            if (listbn != null)
            {
                for (int i = 0; i < listbn.Length; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (i + 1).ToString();
                    lvi.SubItems.Add(tdao.getByPrimaryKey(int.Parse(listbn[i].MaLoaiThuoc.ToString())).TenLoaiThuoc.ToString());
                    lvi.SubItems.Add(donvidao.getByPrimaryKey(int.Parse(tdao.getByPrimaryKey(int.Parse(listbn[i].MaLoaiThuoc.ToString())).MaDonViTinh.ToString())).DonViTinh.ToString());
                    lvi.SubItems.Add(listbn[i].SoLuong.ToString());
                    lvi.SubItems.Add(listbn[i].MaCachDung.ToString());
                    lvi.SubItems.Add(listbn[i].MaLoaiThuoc.ToString());
                    lvi.SubItems.Add(cddao.getByPrimaryKey(int.Parse(listbn[i].MaCachDung.ToString())).CachDung.ToString());
                    lvi.SubItems.Add(cddao.getByPrimaryKey(int.Parse(listbn[i].MaCachDung.ToString())).GhiChu.ToString());
                    lv.Items.Add(lvi);
                }
            }
        }
        public void showInListView1(ListView lv, CT_KhamDTO[] listbn) // dung de show cac ctkham cua mot benh nhân trong tat ca cac ngày
        {
            if (lv.Items.Count > 0)
                lv.Items.Clear();
            if (listbn != null)
            {
                int stt;
                for (int i = 0; i < listbn.Length; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    stt = 1;
                    lvi.Text = (i + 1).ToString();
                    if (i > 0)
                    {
                        if (listbn[i].MaPhieuKhamBenh.ToString().Substring(5).ToString() == listbn[i - 1].MaPhieuKhamBenh.Substring(5).ToString())
                        {
                            lvi.SubItems.Add("");
                            lvi.Text = "";
                        }
                        else
                        {
                            lvi.SubItems.Add(listbn[i].MaPhieuKhamBenh.ToString().Substring(5).ToString());
                            stt++;
                            lvi.Text = stt.ToString();
                        }
                    }
                    else
                    {                       
                        lvi.SubItems.Add(listbn[i].MaPhieuKhamBenh.ToString().Substring(5).ToString());
                        lvi.Text = stt.ToString();
                    }
                    lvi.SubItems.Add(tdao.getByPrimaryKey(int.Parse(listbn[i].MaLoaiThuoc.ToString())).TenLoaiThuoc.ToString());
                    lvi.SubItems.Add(donvidao.getByPrimaryKey(int.Parse(tdao.getByPrimaryKey(int.Parse(listbn[i].MaLoaiThuoc.ToString())).MaDonViTinh.ToString())).DonViTinh.ToString());
                    lvi.SubItems.Add(listbn[i].SoLuong.ToString());
                    lvi.SubItems.Add(cddao.getByPrimaryKey(int.Parse(listbn[i].MaCachDung.ToString())).CachDung.ToString());
                    lvi.SubItems.Add(cddao.getByPrimaryKey(int.Parse(listbn[i].MaCachDung.ToString())).GhiChu.ToString());
                    lv.Items.Add(lvi);
                }
            }
        }
        public CT_KhamDTO[] getListByMaPhieuKham(string maphieukham)
        {
            return dvdao.getListByMaPhieuKham(maphieukham);
        }
        public CT_KhamDTO[] getListByBenhNhan(string mabenhnhan)
        {
            return dvdao.getListMaBenhNhan(mabenhnhan);
        }
        public void insert(CT_KhamDTO bn, CachDungDTO cddto)
        {
            cddto.MaCachDung = cddao.getMaxMaCachDung() + 1;
            int result = cddao.insert(cddto);
            if (result > 0)
            {
                bn.MaCachDung = cddto.MaCachDung;
                int result1 = dvdao.insert(bn);
                if (result1 > 0)
                {                    
                    MessageBox.Show(" Thêm thành công ! ");
                }
                else
                {
                    if (result1 == -2)
                        MessageBox.Show(" Đã tồn tại loại thuốc này trong phiếu khám ! ");
                    else
                        MessageBox.Show(" Thêm thất bại ! ");
                }
            }
            else
            {
                  MessageBox.Show(" Thêm thất bại ! ");
            }
            
        }
        public void update(CT_KhamDTO bn)
        {
            int result1 = dvdao.update(bn);
            if (result1 > 0)
            {
                MessageBox.Show(" Cập nhật thành công ! ");
            }
            else
            {               
                MessageBox.Show(" Cập nhật thất bại ! ");
            }

        }

        public void delete(string mapk, int maloaithuoc, int macachdung)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có thật sự muốn xóa loại thuốc này trong đơn thuốc ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int result1 = dvdao.delete(mapk, maloaithuoc);
                if (result1 > 0)
                {
                  if(cddao.delete(macachdung)>0)
                      MessageBox.Show(" Đã xóa!");
                }
                else
                {
                    if (result1 == -2)
                        MessageBox.Show(" Không thể xóa vì ràng buộc khóa ngoại !");
                    else
                        MessageBox.Show(" Xóa thất bại !");
                }
            }
        }
        public DataTable getDonThuoc(string maphieukham)
        {
            return dvdao.getDonthuoc(maphieukham);
        }
    }
}
