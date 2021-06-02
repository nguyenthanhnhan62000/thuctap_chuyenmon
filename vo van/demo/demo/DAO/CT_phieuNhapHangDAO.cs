using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO
{
    class CT_phieuNhapHangDAO
    {

        private static CT_phieuNhapHangDAO instance;

        public static CT_phieuNhapHangDAO Instance
        {
            get { if (instance == null) instance = new CT_phieuNhapHangDAO(); return instance; }
            private set => instance = value;
        }
         
        public DataTable getDatabyMaPhieuThue( int maPhieuThue)
        {
            DataTable data = DataProvider.Instance.execQ("SELECT * FROM dbo.CT_PHIEUNHAPHANG WHERE MAPHIEUNHAP =" + maPhieuThue + "");
            return data;
        }
        public bool InsertCt_phieuNhapHang(int maPhieuNhap,String maHang,int soLuong)
        {
            int i = 1;
            DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertCt_phieuNhapHang @maPhieuNhap ="+maPhieuNhap+", @maHang = N'"+maHang+"', @soLuong = "+soLuong+" ");
            return i > 0;
        }
    }
}
