using demo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace demo.DAO
{
    class PhieuThueDAO
    {
        private static PhieuThueDAO instance;

        public static PhieuThueDAO Instance
        {
            get { if (instance == null) instance = new PhieuThueDAO(); return instance; }
            private set => instance = value;
        }

        public DataTable getHoaDonByThang(DateTime fromDate, DateTime toDate)
        {
            DataTable data = DataProvider.Instance.execQ(" SELECT * FROM dbo.HoaDon WHERE '" + fromDate + "'<NgayLap AND NgayLap< '" + toDate + "'");
            return data;
        }
        public float getTongTienByThang(DateTime fromDate, DateTime toDate)
        {
            float TienThang = 0;
            try
            {
                TienThang = (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar(" SELECT SUM(TongTien) FROM dbo.HoaDon WHERE '" + fromDate + "'<NgayLap AND NgayLap< '" + toDate + "'"));

            }
            catch (Exception)
            {

            }
            return TienThang;
        }
        public void NhanPhong(int maPhieuThue)
        {
            DataProvider.Instance.execQ("EXEC dbo.USP_nhanPhong @maPhieuThue = " + maPhieuThue + " ");
        }

        public List<PhieuThue> getListPHieuThueByWait()
        {
            List<PhieuThue> listPhieuThue = new List<PhieuThue>();
            DataTable data = DataProvider.Instance.execQ("USP_getListPhieuThueByWait");
            foreach (DataRow item in data.Rows)
            {
                PhieuThue p = new PhieuThue(item);
                listPhieuThue.Add(p);
            }
            return listPhieuThue;

        }
        public void insertPhieuThue(DateTime NgayDen,DateTime NgayDI, int maKH)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_insertPhieuThue @NgayDen = '" + NgayDen + "',  @ngayDi = '" + NgayDI + "', @maKH = " + maKH + "");

        }
        public List<PhieuThue> getListAllPhieuThue()
        {
            List<PhieuThue> listPhieuThue = new List<PhieuThue>();
            DataTable data = DataProvider.Instance.execQ("USP_getListAllPhieuThue");
            foreach (DataRow item in data.Rows)
            {
                PhieuThue p = new PhieuThue(item);
                listPhieuThue.Add(p);
            }
            return listPhieuThue;

        }

        public List<PhieuThue> getListPhieuThueHSD()
        {
            List<PhieuThue> listPhieuThue = new List<PhieuThue>();
            DataTable data = DataProvider.Instance.execQ("EXEC GetListPhieuThueHSD");
            foreach (DataRow item in data.Rows)
            {
                PhieuThue p = new PhieuThue(item);
                listPhieuThue.Add(p);
            }
            return listPhieuThue;

        }
        public List<PhieuThue> getListPhieuThueDangAndCho()
        {
            List<PhieuThue> listPhieuThue = new List<PhieuThue>();
            DataTable data = DataProvider.Instance.execQ("EXEC dbo.GetListPhieuThueDangAndCho");
            foreach (DataRow item in data.Rows)
            {
                PhieuThue p = new PhieuThue(item);
                listPhieuThue.Add(p);
            }
            return listPhieuThue;

        }

        public List<Menu_DV> getListMenuByMaPHieuThue(int MaPhieuThue)
        {
            List<Menu_DV> listMenu = new List<Menu_DV>();
            DataTable data = DataProvider.Instance.execQ("EXECUTE getListDichVuByMaPhieuThue @MaPhieuThue="+MaPhieuThue+"");
            foreach (DataRow item in data.Rows)
            {
                Menu_DV p = new Menu_DV(item);
                listMenu.Add(p);
            }
            return listMenu;

        }
        public PhieuThue getPhieuThueByMaPhong( int maPhong)
        {
           
            String query = "SELECT pt.MaPhieuThue,pt.NgayLap,pt.NgayDen,pt.NgayDi,pt.MaKH,pt.TrangThai FROM dbo.PHIEUTHUE pt, dbo.THUEPHONG tp,dbo.PHONG p " +
                             "WHERE pt.MaPhieuThue=tp.MaPhieuThue AND p.MaPhong=tp.MaPhong AND p.MaPhong="+maPhong+" and pt.TrangThai = N'đang'";
            DataTable data = DataProvider.Instance.execQ(query);
            PhieuThue pt = new PhieuThue();
            foreach (DataRow item in data.Rows)
            {
               pt = new PhieuThue(item);
            }
            return pt;
        }

        public PhieuThue getPhieuThueByMaPhieuThue(int MaPHieuThue)
        {
            String query = "select * from PhieuThue where MaPhieuThue ="+MaPHieuThue+" ";

            DataTable data = DataProvider.Instance.execQ(query);
            PhieuThue pt = new PhieuThue();
            foreach (DataRow item in data.Rows)
            {
                pt = new PhieuThue(item);
            }
            return pt;
        }


    }
}
