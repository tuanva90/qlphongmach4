using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class PhieuKhamBenhDTO
    {
        private int _MaPhieuKhamBenh;
        private string _MaDSKB;
        private string _TrieuChung;
        private int _MaLoaiBenh;
        private int _MaLoaiBenhPhu;
        public PhieuKhamBenhDTO()
        {
        }
        public int MaPhieuKhamBenh
        {
            get { return _MaPhieuKhamBenh; }
            set { _MaPhieuKhamBenh = value; }
        }
       
        public string MaDSKB
        {
            get { return _MaDSKB; }
            set { _MaDSKB = value; }
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
