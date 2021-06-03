using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO
{
    class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set => instance = value;
        }

        public DataTable getDataNhanVien()
        {
            DataTable data = DataProvider.Instance.execQ("select * from NHANVIEN");
            return data;
        }

        public bool InsertNhanVien(String MaNv, String  TenNv,DateTime NgaySinh,String GioiTinh,String DIaCHi,String sdt,float luong)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("INSERT dbo.NHANVIEN( MANV ,TENNV ,NGAYSINH ,GIOITINH ,DIACHI ,SODT ,SOCMND ,MABP ,NGAYVAOLAM ,LUONG) VALUES  ( '"+MaNv+"' , N'"+TenNv+ "' , '"+NgaySinh+"' , N'" + GioiTinh+"' , N'"+DIaCHi+"' , '"+sdt+"' , '12345' , 'MBP01' , GETDATE() , "+luong+" )");
            return i > 0;
        }
        public bool editNhanVien(String MaNv, String TenNv, DateTime NgaySinh, String GioiTinh, String DIaCHi, String sdt, float luong)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("	UPDATE dbo.NHANVIEN SET TENNV=N'"+TenNv+"',NGAYSINH = '"+NgaySinh+"',GIOITINH =N'"+GioiTinh+"',DIACHI = N'"+DIaCHi+"',SODT= '"+sdt+"',LUONG = "+luong+" WHERE MANV = '"+MaNv+"' ");
            return i > 0;
        }
        public bool deleteNhanVien(String MaNv)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.NHANVIEN WHERE	MANV='" + MaNv + "'");
            return i > 0;
        }


    } 
}
