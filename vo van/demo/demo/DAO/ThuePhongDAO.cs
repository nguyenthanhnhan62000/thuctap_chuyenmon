using demo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO
{
    class ThuePhongDAO
    {
        private static ThuePhongDAO instance;

        public static ThuePhongDAO Instance
        {
            get { if (instance == null) instance = new ThuePhongDAO(); return instance; }
            private set => instance = value;
        }
        public DataTable LoadThuePhongByMaPhieuThue( int maPhieuThue)
        {
            DataTable data = DataProvider.Instance.execQ("dbo.USP_LoadThuePhongByMaPhieuThue @maPhieuThue = " + maPhieuThue + "");
            return data;
        }
        public void InsertPhongIntoThuePhong(int MaPhieuThue, int MaPhong)
        {
            String query = "INSERT THUEPHONG ( MaPhieuThue,MaPhong) VALUES(" + MaPhieuThue + ", " + MaPhong + ")";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void DeleteThuePhong(int MaPhieuThue, int MaPhong)
        {
            String query = " EXEC dbo.deleteThuePhong @maPhieuThue = "+MaPhieuThue+",  @maPhong = "+MaPhong+" ";
            DataProvider.Instance.ExecuteNonQuery(query);
         
        }
        public void ChuyenPhong(int MaPhieuThue, int MaPhong,int MaPhongChuyen)
        {
            String query = "EXEC dbo.USP_ChuyenPhong @maPhieuThue = "+MaPhieuThue+",  @maPhong = "+MaPhong+", @maPhongChuyen = "+MaPhongChuyen+"";
            DataProvider.Instance.ExecuteNonQuery(query);

        }
     

    }
}
