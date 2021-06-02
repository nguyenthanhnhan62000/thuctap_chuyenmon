using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DTO
{
    class PhieuNhapTienNghi
    {
        private int maPhieuNhap;
        private String maNhaCC;
        private DateTime thoiGianNhap;
        private String nhanVienNhap;
        private float TongSoTien;

        public int MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }
        public string MaNhaCC { get => maNhaCC; set => maNhaCC = value; }
        public DateTime ThoiGianNhap { get => thoiGianNhap; set => thoiGianNhap = value; }
        public string NhanVienNhap { get => nhanVienNhap; set => nhanVienNhap = value; }
        public float TongSoTien1 { get => TongSoTien; set => TongSoTien = value; }

        public PhieuNhapTienNghi()
        {

        }
        public PhieuNhapTienNghi(int maPhieuNhap, String maNhacc, DateTime thoiGianNhap, String nhanVienNhap, float tongSoTien)
        {
            this.MaPhieuNhap = maPhieuNhap;
            this.MaNhaCC = maNhacc;
            this.ThoiGianNhap = thoiGianNhap;
            this.NhanVienNhap = nhanVienNhap;
            this.TongSoTien1 = tongSoTien;
        }
        public PhieuNhapTienNghi(DataRow row)
        {
            this.MaPhieuNhap = (int)row["maPhieuNhap"];
            this.MaNhaCC = (String)row["maNhaCC"];
            this.ThoiGianNhap = (DateTime)row["thoiGianNhap"];
            if (row["nhanVienNhap"] == null)
                this.NhanVienNhap = (String)row["nhanVienNhap"];
            this.TongSoTien1 = (float)Convert.ToDouble(row["tongSoTien"]);
        }
    }
}
