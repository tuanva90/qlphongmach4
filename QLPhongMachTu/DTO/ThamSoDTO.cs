using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class ThamSoDTO
    {
        private float _TienKham;
        private int _SoBenhNhanToiDa;

        public int SoBenhNhanToiDa
        {
            get { return _SoBenhNhanToiDa; }
            set { _SoBenhNhanToiDa = value; }
        }

        public float TienKham
        {
            get { return _TienKham; }
            set { _TienKham = value; }
        }
    }
}
