using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class NguoiDungDTO
    {
        private int _MaNguoiDung;

        public int MaNguoiDung
        {
            get { return _MaNguoiDung; }
            set { _MaNguoiDung = value; }
        }

        private string _TenDangNhap;
        public string TenDangNhap
        {
            get { return _TenDangNhap; }
            set { _TenDangNhap = value; }
        }

        private string _MatKhau;
        public string MatKhau
        {
            get { return _MatKhau; }
            set { _MatKhau = value; }
        }

        private int _MaPhanQuyen;
        public int MaPhanQuyen
        {
            get { return _MaPhanQuyen; }
            set { _MaPhanQuyen = value; }
        }
       
        public NguoiDungDTO()
        {
        }
        
    }
}
