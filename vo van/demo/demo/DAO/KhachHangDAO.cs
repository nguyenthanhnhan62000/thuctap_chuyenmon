using demo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO
{
    class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            private set => instance = value;
        }
        public bool InsertKhachHang(String TenKH,int sdt)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("INSERT dbo.KHACHHANG(TenKH, Sdt)VALUES(N'"+TenKH+"', "+sdt+")");
            return i > 0;
        }
        public bool EditKhachHang(int MaKH,String TenKH, int sdt)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("	UPDATE dbo.KHACHHANG SET TenKH= N'"+TenKH+"',Sdt="+sdt+" WHERE MaKH ="+MaKH+"");
            return i > 0;
        }
        public bool DeleteKhachHang(int maKh)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.KHACHHANG WHERE	MaKH="+maKh+"");
            return i > 0;
        }
        public KhachHang getKhachHangByMaPhieuThue(int MaPhieuThue)
        {
            String query = "SELECT KHACHHANG.MaKH,TenKH,Sdt FROM dbo.PHIEUTHUE,dbo.KHACHHANG WHERE	KHACHHANG.MaKH= dbo.PHIEUTHUE.MaKH AND MaPhieuThue="+MaPhieuThue+"";
            DataTable data = DataProvider.Instance.execQ(query);
            KhachHang kh = new KhachHang();
            foreach (DataRow item in data.Rows)
            {
                kh = new KhachHang(item);
            }
            return kh;
        }
        public KhachHang getKhachHangByMaKh(int MaKh)
        {
            String query = "SELECT * FROM dbo.KHACHHANG WHERE	KHACHHANG.MaKH= "+MaKh+"";
            DataTable data = DataProvider.Instance.execQ(query);
            KhachHang kh = new KhachHang();
            foreach (DataRow item in data.Rows)
            {
                kh = new KhachHang(item);
            }
            return kh;
        }
        public DataTable getDataKhachHang()
        {
            DataTable data = DataProvider.Instance.execQ("select * from KHACHHANG");

            return data;

        }
        public List<KhachHang> getListKhachHang()
        {
            List<KhachHang> listKhachHang = new List<KhachHang>();
            DataTable data = DataProvider.Instance.execQ("select * from KHACHHANG");
            foreach (DataRow item in data.Rows)
            {
                KhachHang kh = new KhachHang(item);
                listKhachHang.Add(kh);
            }
            return listKhachHang;
        }
    }
}
