using demo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace demo.DAO
{
    class  PhongDAO
    {
        private static PhongDAO instance;

        public static PhongDAO Instance
        {
            get { if (instance == null) instance = new PhongDAO(); return instance; }
            private set => instance = value;
        }

        public DataTable FindPhong(String soPhong)
        {
            return DataProvider.Instance.execQ("SELECT * FROM phong WHERE SoPhong LIKE '%"+soPhong+"%'");
            
        }

        public bool InsertPhong(int soPhong, String trangThai,float donGia,int tang,String loai)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("INSERT dbo.PHONG( SoPhong, TrangThai, DonGia,Tang,Loai )VALUES  ("+soPhong+", N'"+trangThai+"', "+donGia+","+tang+", N'"+loai+"' )");
            return i > 0;
        }
        public bool EditPhong(int maPhong,int soPhong, float donGia,int tang,String loai)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.PHONG SET SoPhong=N'"+soPhong+"', DonGia ="+donGia+",Tang ="+tang+",Loai =N'"+loai+"' WHERE MaPhong="+maPhong+"");
            return i > 0;
        }
        public bool DeletePhong(int maPhong)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.PHONG WHERE MaPhong= "+maPhong+"");
            return i > 0;
        }
        public object getTienPhong(int maPhieuThue)
        {
            object tienPhong = 0;
            tienPhong = DataProvider.Instance.ExecuteScalar("EXEC dbo.getTienPhong @maPhieuThue = "+maPhieuThue+"");
            return tienPhong;
        }
        public List<Phong> getListPhong()
        {
            List<Phong> listPhong = new List<Phong>();

            DataTable data = DataProvider.Instance.execQ("select * from phong");
            foreach (DataRow item in data.Rows)
            {
                Phong p = new Phong(item);
                listPhong.Add(p);

            }

            return listPhong; 
        }
        public List<Phong> getListTrong()
        {
            List<Phong> listPhong = new List<Phong>();

            DataTable data = DataProvider.Instance.execQ("SELECT * FROM dbo.PHONG WHERE TrangThai = N'trống'");
            foreach (DataRow item in data.Rows)
            {
                Phong p = new Phong(item);
                listPhong.Add(p);

            }

            return listPhong;
        }
        public List<Phong> getListCoNguoi()
        {
            List<Phong> listPhong = new List<Phong>();

            DataTable data = DataProvider.Instance.execQ("SELECT * FROM dbo.PHONG WHERE TrangThai = N'có người'");
            foreach (DataRow item in data.Rows)
            {
                Phong p = new Phong(item);
                listPhong.Add(p);

            }

            return listPhong;
        }

        public List<Phong> getListPhongTrong(DateTime TuNgay,DateTime DenNgay)
        {
            String query = " EXECUTE USP_GetListPhongTrongByDate @ngayDen ='"+TuNgay+"', @ngayDi = '"+DenNgay+"'";
            List<Phong> listPhong = new List<Phong>();
            DataTable data = DataProvider.Instance.execQ(query);
            foreach (DataRow item in data.Rows)
            {
                Phong p = new Phong(item);
                listPhong.Add(p);
            }

            return listPhong;
        }

        public List<Phong> getListPhongByMaPhieuThue(int MaPhieuThue)
        {
            String query = "SELECT PHONG.MaPhong,SoPhong,TrangThai,DonGia,Tang,Loai " +
                "FROM dbo.PHONG,dbo.THUEPHONG " +
                "WHERE phong.MaPhong = THUEPHONG.MaPhong AND MaPhieuThue = "+MaPhieuThue+"";

            List<Phong> listPhong = new List<Phong>();
            DataTable data = DataProvider.Instance.execQ(query);
            foreach (DataRow item in data.Rows)
            {
                Phong p = new Phong(item);
                listPhong.Add(p);
            }

            return listPhong;
        }
        public Phong getMaPhongBySoPhong(int SoPhong)
        {
            String query = "SELECT * FROM dbo.PHONG WHERE SoPhong = "+SoPhong+"";

            DataTable data = DataProvider.Instance.execQ(query);
            Phong p = new Phong();
            foreach (DataRow item in data.Rows)
            {
                p = new Phong(item);
            }
            return p;
        }




    }
}
