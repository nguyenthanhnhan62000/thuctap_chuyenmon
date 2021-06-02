using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DTO
{
    class PhieuThue
    {

        private int MaPhieuThue;
        private DateTime NgayLap;
        private DateTime NgayDen;
        private DateTime NgayDi;
        private int MaKH;
        private String TrangThai;

        public PhieuThue() { }

        public PhieuThue(int maphieuthue, DateTime ngayLap,DateTime NgayDen,DateTime NgayDi,int MakH,String trangThai) 
        
        {
            this.MaPhieuThue1 = maphieuthue;
            this.NgayLap = ngayLap;
            this.NgayDen = NgayDen;
            this.NgayDi = NgayDi;
            this.MaKH = MakH;
            this.TrangThai = trangThai;
        }
        public PhieuThue(DataRow row)
        {
            this.MaPhieuThue1 = (int)row["MaPhieuThue"];
            this.NgayLap= (DateTime)row["NgayLap"];
            this.NgayDen = (DateTime)row["NgayDen"];
            this.NgayDi = (DateTime)row["NgayDi"];
            this.MaKH = (int)row["MaKH"];
            if( row["TrangThai"] != null) { this.TrangThai = row["TrangThai"].ToString(); }
            
        }

       
        public DateTime NgayLap1 { get => NgayLap; set => NgayLap = value; }
        public DateTime NgayDen1 { get => NgayDen; set => NgayDen = value; }
        public DateTime NgayDi1 { get => NgayDi; set => NgayDi = value; }
        public int MaKH1 { get => MaKH; set => MaKH = value; }
        public int MaPhieuThue1 { get => MaPhieuThue; set => MaPhieuThue = value; }
        public string TrangThai1 { get => TrangThai; set => TrangThai = value; }
    }
}
