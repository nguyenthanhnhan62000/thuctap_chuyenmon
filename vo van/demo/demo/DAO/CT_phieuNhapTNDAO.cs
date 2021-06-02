using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO
{
    class CT_phieuNhapTNDAO
    {

        private static CT_phieuNhapTNDAO instance;

        public static CT_phieuNhapTNDAO Instance
        {
            get { if (instance == null) instance = new CT_phieuNhapTNDAO(); return instance; }
            private set => instance = value;
        } 
        public DataTable getDatabyMaPhieuThue(int maPhieuThue)
        {
            DataTable data = DataProvider.Instance.execQ("SELECT * FROM dbo.CT_PHIEUNHAPTIENNGHI WHERE MAPHIEUNHAP =" + maPhieuThue + "");
            return data;
        }
        public bool InsertCt_phieuNhapTN(int maPhieuNhap, String maTN, int soLuong)
        {
            int i = 1;
            DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertCt_phieuNhapTN @maPhieuNhap =" + maPhieuNhap + ", @maTN = N'" + maTN + "', @soLuong = " + soLuong + " ");
            return i > 0;
        }
    }
}
