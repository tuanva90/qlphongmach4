using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class CachDungDTO
    {
        private int _MaCachDung;
        private string _CachDung;
        private int _Sang;
        private int _Trua;
        private int _Chieu;
        private int _Toi;
        private string _GhiChu;
        public CachDungDTO()
        {
        }

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }     

        public int Toi
        {
            get { return _Toi; }
            set { _Toi = value; }
        }

        public int Chieu
        {
            get { return _Chieu; }
            set { _Chieu = value; }
        }

        public int Trua
        {
            get { return _Trua; }
            set { _Trua = value; }
        }

        public int Sang
        {
            get { return _Sang; }
            set { _Sang = value; }
        }

        public string CachDung
        {
            get { return _CachDung; }
            set { _CachDung = value; }
        }


        public int MaCachDung
        {
            get { return _MaCachDung; }
            set { _MaCachDung = value; }
        }
    }
}
