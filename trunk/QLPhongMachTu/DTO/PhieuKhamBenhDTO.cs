using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class PhieuKhamBenhDTO
    {
        private string _MaPhieuKhamBenh;
        private string _MaBenhNhan;
        private string _NgayKham;       
        private string _TrieuChung;
        private int _MaLoaiBenh;
        private int _MaLoaiBenhPhu;

        public string NgayKham
        {
            get { return _NgayKham; }
            set { _NgayKham = value; }
        }
        public PhieuKhamBenhDTO()
        {
        }
        public string MaPhieuKhamBenh
        {
            get { return _MaPhieuKhamBenh; }
            set { _MaPhieuKhamBenh = value; }
        }
       
        public string MaBenhNhan
        {
            get { return _MaBenhNhan; }
            set { _MaBenhNhan = value; }
        }
       
        public string TrieuChung
        {
            get { return _TrieuChung; }
            set { _TrieuChung = value; }
        }
       
        public int MaLoaiBenh
        {
            get { return _MaLoaiBenh; }
            set { _MaLoaiBenh = value; }
        }
       
        public int MaLoaiBenhPhu
        {
            get { return _MaLoaiBenhPhu; }
            set { _MaLoaiBenhPhu = value; }
        }
    }
}
