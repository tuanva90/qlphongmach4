using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class NhapKhoDTO
    {
        private int _MaLoaiThuoc;

        public int MaLoaiThuoc
        {
            get { return _MaLoaiThuoc; }
            set { _MaLoaiThuoc = value; }
        }
        private string _NgayKham;

        public string NgayNhap
        {
            get { return _NgayKham; }
            set { _NgayKham = value; }
        }
        private int _LanKham;

        public int LanNhap
        {
            get { return _LanKham; }
            set { _LanKham = value; }
        }
        private float _DonGiaNhap;

        public float DonGiaNhap
        {
            get { return _DonGiaNhap; }
            set { _DonGiaNhap = value; }
        }
        private float _SoLuong;

        public float SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
       public NhapKhoDTO()
       {
       }
    }
}
