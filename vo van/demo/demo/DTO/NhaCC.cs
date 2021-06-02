using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DTO
{
    class NhaCC
    {

        private String maNhaCC;
        private String tenNhaCC;
        private String sdt;
        private String diaChi;
        private String tenNguoiLH;
        private String ThongTinKhac;
        public NhaCC()
        {
            
        }
        public NhaCC(String maNhaCC, String tenNhaCC, String sdt,String diaChi,String tenNguoiLH,String thongTinKhac)
        {
            this.maNhaCC = maNhaCC;
            this.tenNhaCC = tenNhaCC;
            this.sdt = sdt;
            this.diaChi = diaChi;
            this.tenNguoiLH = tenNguoiLH;
            this.ThongTinKhac = thongTinKhac;
        }
        public NhaCC(DataRow row)
        {
            this.maNhaCC = (String)row["maNhaCC"];
            this.tenNhaCC = (String)row["tenNhaCC"];
            this.sdt = (String)row["sodt"];
            this.diaChi = (String)row["diaChi"];
            this.tenNguoiLH = (String)row["tenNguoiLH"];
            if(row["thongTinKhac"] ==null)
            this.ThongTinKhac = (String)row["thongTinKhac"];
        }

        public string MaNhaCC { get => maNhaCC; set => maNhaCC = value; }
        public string TenNhaCC { get => tenNhaCC; set => tenNhaCC = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string TenNguoiLH { get => tenNguoiLH; set => tenNguoiLH = value; }
        public string ThongTinKhac1 { get => ThongTinKhac; set => ThongTinKhac = value; }
    }
}
