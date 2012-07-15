using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class LoaiBenhDTO
    {
        private int _MaLoaiBenh;
        private string _TenLoaiBenh;
        public LoaiBenhDTO()
        {
        }
        public string TenLoaiBenh
        {
            get { return _TenLoaiBenh; }
            set { _TenLoaiBenh = value; }
        }


        public int MaLoaiBenh
        {
            get { return _MaLoaiBenh; }
            set { _MaLoaiBenh = value; }
        }
    }
}
