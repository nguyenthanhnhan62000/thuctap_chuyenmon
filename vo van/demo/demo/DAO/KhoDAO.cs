using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO 
{
    class KhoDAO
    {
        private static KhoDAO instance;

        public static KhoDAO Instance
        {
            get { if (instance == null) instance = new KhoDAO(); return instance; }
            private set => instance = value;
        }
        public DataTable getDataKho()
        {
            DataTable data = DataProvider.Instance.execQ("	SELECT * FROM dbo.KHO");
            return data;

        }

        public bool InsertKho(String MaKho, String TenKho, String Vitri, String MoTa )
        {
            int i = DataProvider.Instance.ExecuteNonQuery("INSERT dbo.KHO( MAKHO, TENKHO, VITRI, MOTA )VALUES  ( '"+MaKho+"',N'"+TenKho+"', N'"+Vitri+"', N'"+MoTa+"')");
            return i > 0;
        }
        public bool EditKho(String MaKho, String TenKho, String Vitri, String MoTa)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.KHO SET TENKHO=N'" + TenKho + "', VITRI =N'" + Vitri + "',MoTa =N'" + MoTa + "' WHERE MAKHO='" + MaKho + "'");
            return i > 0;
        }
        public bool DeleteKho(String MaKho)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.KHO WHERE MAKHO= '" + MaKho + "'");
            return i > 0;
        }
    }
}
