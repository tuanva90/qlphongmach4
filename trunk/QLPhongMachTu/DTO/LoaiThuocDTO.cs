using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class LoaiThuocDTO
    {
        private int _MaLoaiThuoc;
        private string _TenLoaiThuoc;
        private int _MaDonViTinh;
        private float _DonGia;
        private float _SoLuong;
        private float _SLToiThieu;
        public LoaiThuocDTO()
        {
        }

        public float SLToiThieu
        {
            get { return _SLToiThieu; }
            set { _SLToiThieu = value; }
        }

        public float SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }

        public float DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }


        public int MaDonViTinh
        {
            get { return _MaDonViTinh; }
            set { _MaDonViTinh = value; }
        }


        public string TenLoaiThuoc
        {
            get { return _TenLoaiThuoc; }
            set { _TenLoaiThuoc = value; }
        }

        public int MaLoaiThuoc
        {
            get { return _MaLoaiThuoc; }
            set { _MaLoaiThuoc = value; }
        }
    }
}
