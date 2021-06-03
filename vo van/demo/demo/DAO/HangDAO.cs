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

        public bool InsertHang(String MaH, String TenH,String DVT,float Gia, int SoLuong)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("INSERT dbo.HANG( MAHANG ,MAKHO ,TENHANG ,DONVITINH ,GIA ,SOLUONG )VALUES  ( '"+MaH+"' ,  'MK01' ,  N'"+TenH+"' , N'"+DVT+"' , "+Gia+" , "+SoLuong+")");
            return i > 0;
        }
        public bool EditHang(String MaH, String TenH, String DVT, float Gia, int SoLuong)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.HANG SET TENHANG=N'" + TenH + "', DONVITINH ='" + DVT + "',GIA =" + Gia + ",SOLUONG =" + SoLuong + "WHERE MAHANG='" + MaH + "'");
            return i > 0;
        }
        public bool DeleteHang(String maH)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.HANG WHERE MAHANG= '" + maH + "'");
            return i > 0;
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
