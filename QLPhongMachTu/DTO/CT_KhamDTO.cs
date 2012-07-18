using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class CT_KhamDTO
    {
        private string _MaCT_Kham;
        private string _MaPhieuKhamBenh;
        private int _MaLoaiThuoc;
        private float _SoLuong;
        private int _MaCachDung;
        private float _DonGia;

        public float DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }
        public CT_KhamDTO()
        {
        }

        public int MaCachDung
        {
            get { return _MaCachDung; }
            set { _MaCachDung = value; }
        }

        public float SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }

        public int MaLoaiThuoc
        {
            get { return _MaLoaiThuoc; }
            set { _MaLoaiThuoc = value; }
        }

        public string MaPhieuKhamBenh
        {
            get { return _MaPhieuKhamBenh; }
            set { _MaPhieuKhamBenh = value; }
        }


        public string MaCT_Kham
        {
            get { return _MaCT_Kham; }
            set { _MaCT_Kham = value; }
        }

    }
}
