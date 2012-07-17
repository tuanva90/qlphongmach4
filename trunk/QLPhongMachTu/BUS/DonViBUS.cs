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
    public class DonViBUS
    {
        private DonViDAO dvdao = new DonViDAO();
        public void showInListView(ListView lv)
        {
            DonViDTO[] listbn =dvdao.getList();
            if (lv.Items.Count > 0)
                lv.Items.Clear();
            if (listbn != null)
            {
                for (int i = 0; i < listbn.Length; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (i + 1).ToString();
                    lvi.SubItems.Add(listbn[i].DonViTinh.ToString());
                    lvi.SubItems.Add(listbn[i].MaDonViTinh.ToString()); 
                    lv.Items.Add(lvi);
                }
            }
        }
        public void insert(DonViDTO bn)
        {           
            if (bn.DonViTinh=="")
            {
                MessageBox.Show(" Nhập tên đơn vị tính !");
            }
            else
            {
                DonViDTO[] dv = dvdao.getList();
                if(dv!=null||dv.Length==0)
                {
                    bool check = false; // kieim tra trung ten
                        for (int i = 0; i < dv.Length; i++)
                        {
                            if (bn.DonViTinh.Equals(dv[i].DonViTinh.ToString()))
                            {                               
                                check = true;
                                break;
                            }
                        }
                        if (check != true)
                        {
                            int result = dvdao.insert(bn);
                            if (result > 0)
                                MessageBox.Show(" Thêm đơn vị tính thành công !");
                            else
                                MessageBox.Show(" Thêm đơn vị tính thất bại !");
                        }
                        else
                            MessageBox.Show(" Tên đơn vị tính đã tồn tại !");
                }             
                else
                {
                    int result = dvdao.insert(bn);
                    if (result > 0)
                        MessageBox.Show(" Thêm đơn vị tính thành công !");
                    else
                        MessageBox.Show(" Thêm đơn vị tính thất bại !");
                }
            }
        }
        public void update(DonViDTO bn)
        {
            if (bn.DonViTinh == "")
            {
                MessageBox.Show(" Nhập tên đơn vị tính !");
            }
            else
            {
                DonViDTO[] dv = dvdao.getList();
                if (dv != null||dv.Length==0)
                {
                    bool check=false; // kieim tra trung ten
                    for (int i = 0; i < dv.Length; i++)
                    {
                        if (bn.DonViTinh==(dv[i].DonViTinh.ToString()))
                        {                           
                            check = true;
                            break;
                        }
                    }
                    if (check != true)
                    {
                        int result = dvdao.update(bn);
                        if (result > 0)
                            MessageBox.Show(" Cập nhật thông tin đơn vị tính thành công !");
                        else
                            MessageBox.Show(" Cập nhật thông tin đơn vị tính thất bại !");
                    }
                    else
                        MessageBox.Show(" Tên đơn vị tính đã tồn tại !");
                }
                else
                {
                    int result = dvdao.update(bn);
                    if (result > 0)
                        MessageBox.Show(" Cập nhật thông tin đơn vị tính thành công !");
                    else
                        MessageBox.Show(" Cập nhật thông tin đơn vị tính thất bại !");
                }
            }

        }

        public void delete(int ma)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có thật sự muốn xóa đơn vị tính này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int result1 = dvdao.delete(ma);
                if (result1 > 0)
                    MessageBox.Show(" Đã xóa!");
                else
                {
                    if (result1 == -2)
                        MessageBox.Show(" Không thể xóa vì ràng buộc khóa ngoại !");
                    MessageBox.Show(" Xóa thất bại !");
                }
            }
        }
    }
}
