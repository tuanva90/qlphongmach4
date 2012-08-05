using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class PhanQuyenDTO
    {
        private int _MaPhanQuyen;
        private string _TenPhanQuyen;
        public PhanQuyenDTO()
        {
        }
        public string TenPhanQuyen
        {
            get { return _TenPhanQuyen; }
            set { _TenPhanQuyen = value; }
        }


        public int MaPhanQuyen
        {
            get { return _MaPhanQuyen; }
            set { _MaPhanQuyen = value; }
        }
    }
}
