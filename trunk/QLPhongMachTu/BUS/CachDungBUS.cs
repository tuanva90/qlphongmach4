using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;
using System.Data;
using System.Windows.Forms;

namespace BUS
{
    public class CachDungBUS
    {
        private CachDungDAO bndao = new CachDungDAO();       
        public void insert(CachDungDTO bn)
        {          

                    int result = bndao.insert(bn);
                    if (result <=0)
                        MessageBox.Show(" Thêm thất bại !");                
        }
        public void update(CachDungDTO bn)
        {
            int result = bndao.update(bn);
            if (result <= 0)
                MessageBox.Show(" Cập nhật thất bại !");
            else
                MessageBox.Show(" Cập nhật thành công !");
        }
        public CachDungDTO getByPrimaryKey(int macd)
        {
            return bndao.getByPrimaryKey(macd);
        }
        public DataTable getCachDung()
        {
            return bndao.getCachdung();
        }
    }
}
