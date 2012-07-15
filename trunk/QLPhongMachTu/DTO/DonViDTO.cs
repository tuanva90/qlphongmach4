using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class DonViDTO
    {
        private int _MaDonViTinh;
        private string _DonViTinh;
        public DonViDTO()
        {
        }

        public string DonViTinh
        {
            get { return _DonViTinh; }
            set { _DonViTinh = value; }
        }


        public int MaDonViTinh
        {
            get { return _MaDonViTinh; }
            set { _MaDonViTinh = value; }
        }

    }
}
