using demo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO
{
    class HangDAO
    {
        private static HangDAO instance;

        public static HangDAO Instance
        {
            get { if (instance == null) instance = new HangDAO(); return instance; }
            private set => instance = value;
        }

        

        public List<Hang> getListHang()
        {
            List<Hang> listHang = new List<Hang>();
            DataTable data = DataProvider.Instance.execQ("SELECT * FROM dbo.hang");
            foreach (DataRow item in data.Rows)
            {
                Hang dv = new Hang(item);
                listHang.Add(dv);
            }

            return listHang;
        }

        public List<Hang> findHang(String TenHang)
        {
            List<Hang> listHang = new List<Hang>();
            DataTable data = DataProvider.Instance.execQ("SELECT * FROM dbo.hang where TENHANG like N'%"+TenHang+"%'");
            foreach (DataRow item in data.Rows)
            {
                Hang dv = new Hang(item);
                listHang.Add(dv);
            }

            return listHang;
        }
    }
}
