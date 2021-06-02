using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DTO
{
    class CT_phieuNhapHang
    {
        private int id;
        private int maPhieuNhap;
        private String maHang;
        private int soLuong;
        public CT_phieuNhapHang()
        {

        }
        public CT_phieuNhapHang(int id,int maPhieuNhap,String maHang,int soLuong) 
        {
            this.id = id;
            this.maPhieuNhap = maPhieuNhap;
            this.maHang = maHang;
            this.soLuong = soLuong;
        }
        public CT_phieuNhapHang(DataRow row)
        {
            this.id = (int)row["id"];
            this.maPhieuNhap = (int)row["maPhieuNhap"];
            this.maHang = (String)row["maHang"];
            this.soLuong = (int)row["soLuong"];
        }

        public int MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }
        public string MaHang { get => maHang; set => maHang = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int Id { get => id; set => id = value; }
    }
}
