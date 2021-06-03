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
        public bool InsertTN(String MaTN, String TenTN, String TinhTrang, int SLHienCo, int Gia)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("	INSERT dbo.TIENNHGI( MATN ,TENTN ,TINHTRANGTN ,SOLUONGHIENCO ,GIA , MAKHO) VALUES  ( '"+MaTN+"' ,  N'"+TenTN+"' ,  N'"+TinhTrang+"' ,"+SLHienCo+" , "+Gia+" , 'MK02' )");
            return i > 0;
        }
        public bool EditTN(String MaTN, String TenTN, String TinhTrang, int SLHienCo, int Gia)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.TIENNHGI SET TENTN=N'" + TenTN + "', TINHTRANGTN =N'" + TinhTrang + "',SOLUONGHIENCO =" + SLHienCo + ",GIA =" + Gia + " WHERE MATN='" + MaTN + "'");
            return i > 0;
        }
        public bool DeleteTN(String MaTN)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.TIENNHGI WHERE MATN= '" + MaTN + "'");
            return i > 0;
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
