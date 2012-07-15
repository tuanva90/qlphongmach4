using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class HoaDonDTO
       {
           private int _SoHoaDon;
           private int _MaPhieuKhamBenh;
           private float _TiemKham;
           private float _TienThuoc;
           public HoaDonDTO()
           {
           }
           public float TienThuoc
           {
               get { return _TienThuoc; }
               set { _TienThuoc = value; }
           }

           public float TiemKham
           {
               get { return _TiemKham; }
               set { _TiemKham = value; }
           }

           public int MaPhieuKhamBenh
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
