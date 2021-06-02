using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DTO
{
    class CT_phieuNhapTN
    {
        private int id;
        private int maPhieuNhap;
        private String maTN;
        private int soLuong;

        public int MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }
  
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string MaTN { get => maTN; set => maTN = value; }
        public int Id { get => id; set => id = value; }

        public CT_phieuNhapTN()
        {

        }
        public CT_phieuNhapTN(int id,int maPhieuNhap, String maTN, int soLuong)
        {
            this.MaPhieuNhap = maPhieuNhap;
            this.maTN = maTN;
            this.SoLuong = soLuong;
        }
        public CT_phieuNhapTN(DataRow row)
        {
            this.id = (int)row["id"];
            this.MaPhieuNhap = (int)row["maPhieuNhap"];
            this.MaTN = (String)row["maTN"];
            this.SoLuong = (int)row["soLuong"];
        }
    }
}
