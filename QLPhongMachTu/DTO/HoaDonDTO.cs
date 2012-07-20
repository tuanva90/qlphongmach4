using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class HoaDonDTO
       {
           private int _SoHoaDon;
           private string _MaPhieuKhamBenh;
           private float _TienKham;
           private float _TienThuoc;
           public HoaDonDTO()
           {
           }
           public float TienThuoc
           {
               get { return _TienThuoc; }
               set { _TienThuoc = value; }
           }

           public float TienKham
           {
               get { return _TienKham; }
               set { _TienKham = value; }
           }

           public string MaPhieuKhamBenh
           {
               get { return _MaPhieuKhamBenh; }
               set { _MaPhieuKhamBenh = value; }
           }

           public int SoHoaDon
           {
               get { return _SoHoaDon; }
               set { _SoHoaDon = value; }
           }

    }
}
