using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;
namespace BUS
{
   public class ThamSoBUS
    {
       ThamSoDAO tsdao = new ThamSoDAO();
       public ThamSoDTO getThamSo()
       {
           return tsdao.getThamSo();
       }
    }
}
