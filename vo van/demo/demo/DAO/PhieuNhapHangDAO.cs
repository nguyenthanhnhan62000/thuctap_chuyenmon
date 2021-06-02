using demo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO
{
    class PhieuNhapHangDAO
    {

        private static PhieuNhapHangDAO instance;

        public static PhieuNhapHangDAO Instance
        {
            get { if (instance == null) instance = new PhieuNhapHangDAO(); return instance; }
            private set => instance = value;
        }

        public bool insetPhieuNhapHang(String maNhaCC)
        {
            int i= DataProvider.Instance.ExecuteNonQuery("	EXEC dbo.USP_insertPhieuThueHang @maNcc = '"+maNhaCC+"' ");

            return i > 0;
        }
        public bool updateTongTienNhapHang(int maPhieuNhap)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.getTongTienNhapHang @maPhieuthue = "+ maPhieuNhap + "");

            return i > 0;
        }

        public List<PhieuNhapHang> getListPhieuNhapHang()
        {
            List<PhieuNhapHang> listPhieuNhapHang = new List<PhieuNhapHang>();
            DataTable data = DataProvider.Instance.execQ("select top 1 * from PHIEUNHAPHANG order by  MAPHIEUNHAP DESC");
            foreach (DataRow item in data.Rows)
            {
                PhieuNhapHang kh = new PhieuNhapHang(item);
                listPhieuNhapHang.Add(kh);
            }
            return listPhieuNhapHang;
        }
    }
}
