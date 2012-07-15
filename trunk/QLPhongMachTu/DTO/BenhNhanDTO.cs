using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class BenhNhanDTO
    {
        private string _MaBenhNhan;

        public string MaBenhNhan
        {
            get { return _MaBenhNhan; }
            set { _MaBenhNhan = value; }
        }

        private string _HoTen;
        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }

        private string _GioiTinh;
        public string GioiTinh
        {
            get { return _GioiTinh; }
            set { _GioiTinh = value; }
        }

        private string _NamSinh;
        public string NamSinh
        {
            get { return _NamSinh; }
            set { _NamSinh = value; }
        }

        private string _DiaChi;
        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }

        private string _SoDienThoai;
        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { _SoDienThoai = value; }
        }

        public BenhNhanDTO()
        {
        }
        
    }
}
