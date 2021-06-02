using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DTO
{
    class PhieuNhapHang
    {
        private int maPhieuNhap;
        private String maNhaCC;
        private DateTime thoiGianNhap;
        private String nhanVienNhap;
        private float TongSoTien;

        public PhieuNhapHang()
        {

        }
        public PhieuNhapHang(int maPhieuNhap,String maNhacc, DateTime thoiGianNhap, String nhanVienNhap,float tongSoTien)
        {
            this.maPhieuNhap = maPhieuNhap;
            this.maNhaCC = maNhacc;
            this.thoiGianNhap = thoiGianNhap;
            this.nhanVienNhap = nhanVienNhap;
            this.TongSoTien = tongSoTien;
        }
        public PhieuNhapHang(DataRow row)
        {
            this.maPhieuNhap = (int)row["MaPhieuNhap"];
            this.maNhaCC = (String)row["maNhaCC"];
            this.thoiGianNhap = (DateTime)row["thoiGianNhap"];
            if(row["nhanVienNhap"]== null)
            this.nhanVienNhap = (String)row["nhanVienNhap"];
            this.TongSoTien = (float)Convert.ToDouble( row["tongSotien"]);
        }


        public int MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }
        public string MaNhaCC { get => maNhaCC; set => maNhaCC = value; }
        public DateTime ThoiGianNhap { get => thoiGianNhap; set => thoiGianNhap = value; }
        public string NhanVienNhap { get => nhanVienNhap; set => nhanVienNhap = value; }
        public float TongSoTien1 { get => TongSoTien; set => TongSoTien = value; }
    }
}
