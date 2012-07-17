using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;
using System.Data;
using System.Windows.Forms;

namespace BUS
{
    public class DSKBBUS
    {
        private DSKBDAO dao = new DSKBDAO();
        public void insert(DSKBDTO dto)
        {
            if(dao.insert(dto)>0)
                MessageBox.Show(" Đã thêm bệnh nhân " + dto.MaBenhNhan +" vào danh sách khám bệnh ngày "+ dto.NgayKham + " !");
            else
                MessageBox.Show(" Bệnh nhân " + dto.MaBenhNhan +" đã có trong danh sách khám bệnh ngày "+ dto.NgayKham + " !");
        }
        public void delete(DSKBDTO dto)
        {
            int result = dao.delete(dto);
            if (result > 0)
                MessageBox.Show(" Đã xóa bệnh nhân " + dto.MaBenhNhan + " khỏi danh sách khám bệnh ngày " + dto.NgayKham + " !");
            else
            {
                if (result == -2)
                    MessageBox.Show(" Không thể xóa vì ràng buộc khóa ngoại !");
                else
                    MessageBox.Show(" Không thể xóa  !");
            }
        }
    }
}
