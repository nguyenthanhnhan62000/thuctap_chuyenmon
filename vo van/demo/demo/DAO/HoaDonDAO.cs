using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO
{
    class HoaDonDAO
    {

        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return instance; }
            private set => instance = value;
        }
        public void ThanhToanHoaDon(int maPhieuThue,float tienPhong,float tienDichVu,float tongTien,String tennv)
        {
            DataProvider.Instance.execQ(String.Format("EXEC dbo.USP_UpdateHoaDon @maPhieuThue = {0},@tienPhong ={1},@tienDichVu = {2},@tongTien ={3},@tenNv = {4}",maPhieuThue,tienPhong,tienDichVu,tongTien,tennv));
        }

        public DataTable GetDoanhThueTheoNgay()
        {
            return DataProvider.Instance.execQ("SELECT MONTH(NgayLap) AS thang ,SUM(TongTien) AS tongtien FROM dbo.HOADON WHERE YEAR(GETDATE()) = YEAR(NgayLap) GROUP BY MONTH(NgayLap)");

        }
        public DataTable GetDoanhThueTheoThang(int Nam)
        {
            return DataProvider.Instance.execQ("SELECT MONTH(NgayLap) AS thang ,SUM(TongTien) AS tongtien FROM dbo.HOADON WHERE YEAR(NgayLap) = "+Nam+ " GROUP BY MONTH(NgayLap)");

        }



    }
}
