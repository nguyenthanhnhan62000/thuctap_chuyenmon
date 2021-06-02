using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DTO
{
    class KhachHang
    {

        private int MaKH;
        private String TenKH;
        private int Sdt;

        public KhachHang()
        {

        }
        public KhachHang( int maKh, String TenKh, int sdt)
        {
            this.MaKH = maKh;
            this.TenKH = TenKh;
            this.Sdt = sdt;
        }
        public KhachHang( DataRow row)
        {
            this.MaKH = (int)row["MaKH"];
            this.TenKH = (String)row["TenKh"];
            if(row["Sdt"] != null)
            {
                this.Sdt = Convert.ToInt32(row["sdt"]);
            } 
        }

        public int MaKH1 { get => MaKH; set => MaKH = value; }
        public string TenKH1 { get => TenKH; set => TenKH = value; }
        public int Sdt1 { get => Sdt; set => Sdt = value; }

    }
}
