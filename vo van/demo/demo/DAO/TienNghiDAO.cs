using demo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO
{
    class TienNghiDAO
    {

            private static TienNghiDAO instance;

            public static TienNghiDAO Instance
            {
                get { if (instance == null) instance = new TienNghiDAO(); return instance; }
                private set => instance = value;

            }


        public List<TienNghi> getListTienNghi()
        {
            List<TienNghi> listTienNghi = new List<TienNghi>();
            DataTable data = DataProvider.Instance.execQ("SELECT * FROM dbo.TIENNHGI");
            foreach (DataRow item in data.Rows)
            {
                TienNghi dv = new TienNghi(item);
                listTienNghi.Add(dv);
            }

            return listTienNghi;
        }

        public List<TienNghi> findTN(String TenTN)
        {
            List<TienNghi> listTienNghi = new List<TienNghi>();
            DataTable data = DataProvider.Instance.execQ("SELECT * FROM dbo.TIENNHGI where TENTN LIKE N'%"+TenTN+"%'");
            foreach (DataRow item in data.Rows)
            {
                TienNghi dv = new TienNghi(item);
                listTienNghi.Add(dv);
            }

            return listTienNghi;
        }

    }
}
