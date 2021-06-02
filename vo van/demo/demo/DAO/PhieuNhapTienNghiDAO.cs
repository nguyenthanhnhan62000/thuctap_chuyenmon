using demo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO
{
    class PhieuNhapTienNghiDAO
    {
        private static PhieuNhapTienNghiDAO instance;

        public static PhieuNhapTienNghiDAO Instance
        {
            get { if (instance == null) instance = new PhieuNhapTienNghiDAO(); return instance; }
            private set => instance = value;
        }
        public bool insetPhieuNhapTN(String maNhaCC)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("	EXECUTE USP_insertPhieuNhapTienNghi @maNcc = '" + maNhaCC+"'");

            return i > 0;
        }
        public bool updateTongTienNhapTN(int maPhieuNhap)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.getTongTienNhapTN @maPhieuthue = " + maPhieuNhap + "");

            return i > 0;
        }
        public List<PhieuNhapTienNghi> getListPhieuNhapTN()
        {
            List<PhieuNhapTienNghi> listPhieuNhapTienNghi = new List<PhieuNhapTienNghi>();
            DataTable data = DataProvider.Instance.execQ("select  TOP 1 * from PHIEUNHAPTIENNGHI ORDER BY MAPHIEUNHAP DESC");
            foreach (DataRow item in data.Rows)
            {
                PhieuNhapTienNghi kh = new PhieuNhapTienNghi(item);
                listPhieuNhapTienNghi.Add(kh);
            }
            return listPhieuNhapTienNghi;
        }
    }
}
