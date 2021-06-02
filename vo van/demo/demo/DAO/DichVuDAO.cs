using demo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO
{
    class DichVuDAO
    {
        private static DichVuDAO instance;

        public static DichVuDAO Instance
        {
            get { if (instance == null) instance = new DichVuDAO(); return instance; }
            private set => instance = value;
        }

        public bool InsertDichVu(String name, float gia)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("INSERT dbo.DICHVU ( name, gia )VALUES  ( N'"+name+"',"+gia+")");
            return i > 0;
        }
        public bool editDichVu(int maDichVu,String name, float gia)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("	UPDATE dbo.DICHVU SET name=N'"+name+"',gia ="+gia+" WHERE MaDichVu="+maDichVu+" ");
            return i > 0;
        }
        public bool deleteDichVu(int maDichVu)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.DICHVU WHERE	MaDichVu="+maDichVu+"");
            return i > 0;
        }

        public List<DichVu> getListDichVu()
        {
            List<DichVu> listDV = new List<DichVu>();
            DataTable data = DataProvider.Instance.execQ("SELECT * FROM dbo.DICHVU");
            foreach (DataRow item in data.Rows)
            {
                DichVu dv = new DichVu(item);
                listDV.Add(dv);
            }

            return listDV;
        }
        public void insertDichVuIntoPhieuThue(int maPhieuThue, int maDichVu, int soLuong)
        {
            DataProvider.Instance.ExecuteNonQuery(" EXEC dbo.USP_insertDichVuIntoPhieuThue @maPhieuThue = "+maPhieuThue+",@maDichVu = "+maDichVu+",   @soLuong ="+soLuong+"");
        }
    }
}
