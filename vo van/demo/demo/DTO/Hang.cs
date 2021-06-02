using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DTO
{
    class Hang
    {
        private String maHang;
        private String maKho;
        private String tenHang;
        private String donViTinh;
        private float gia;
        private int soLuong;
        private String moTa;

        public Hang()
        {

        }
        public Hang(String maHang,String maKho,String tenHang,String donViTinh,float gia,int soLuong,String moTa) 
        {
            this.maHang = maHang;
            this.maKho = maKho;
            this.tenHang = tenHang;
            this.donViTinh = donViTinh;
            this.gia = gia;
            this.soLuong = soLuong;
            this.moTa = moTa;
        }
        public Hang(DataRow row)
        {
            this.maHang = (String)row["maHang"];
            this.maKho = (String)row["maKho"];
            this.tenHang = (String)row["tenHang"];
            this.donViTinh = (String)row["donViTinh"];
            this.gia = (float)Convert.ToDouble( row["gia"]);
            this.soLuong = (int)row["soLuong"];
            if(row["moTa"] == null)
            this.moTa = (String)row["moTa"];
        }

        public string MaHang { get => maHang; set => maHang = value; }
        public string MaKho { get => maKho; set => maKho = value; }
        public string TenHang { get => tenHang; set => tenHang = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public float Gia { get => gia; set => gia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string MoTa { get => moTa; set => moTa = value; }
    }
}
