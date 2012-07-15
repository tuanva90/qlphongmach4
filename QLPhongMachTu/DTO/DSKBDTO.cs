using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DT
{
    public class DSKBDTO
    {
        private string _MaDSKB;
        public string MaDSKB
        {
            get { return _MaDSKB; }
            set { _MaDSKB = value; }
        }

        private string _MaBenhNhan;
        public string MaBenhNhan
        {
            get { return _MaBenhNhan; }
            set { _MaBenhNhan = value; }
        }

        private string _NgayKham;
        public string NgayKham
        {
            get { return _NgayKham; }
            set { _NgayKham = value; }
        }
    }
}
