using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DTO
{
    class TienNghi
    {

        private String maTN;
        private String tenTN;
        private String TinhTrang;
        private int soLuong;
        private int gia;
        private String maKho;

        public TienNghi()
        {

        }
        public TienNghi(String maTN, String tenTN,String tinhTrang, int soLuong,int gia,String maKho)
        {
            this.maTN = maTN;
            this.tenTN = tenTN;
            this.TinhTrang = tinhTrang;
            this.soLuong = soLuong;
            this.gia = gia;
            this.maKho = maKho;
        }
        public TienNghi(DataRow row)
        {
            this.maTN = (String)row["maTN"];
            this.tenTN = (String)row["tenTN"];
            this.TinhTrang = (String)row["tinhTrangTN"];
            this.soLuong = (int)row["soLuongHienCo"];
            this.gia = (int)row["gia"];
            this.maKho = (String)row["maKho"];
        }


        public string MaTN { get => maTN; set => maTN = value; }
        public string TenTN { get => tenTN; set => tenTN = value; }
        public string TinhTrang1 { get => TinhTrang; set => TinhTrang = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int Gia { get => gia; set => gia = value; }
        public string MaKho { get => maKho; set => maKho = value; }
    }
}
